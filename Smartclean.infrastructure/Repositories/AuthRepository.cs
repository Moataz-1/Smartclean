using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Crypto.Macs;
using Smartclean.core.DTO;
using Smartclean.core.Entities;
using Smartclean.core.Interfaces;
using Smartclean.core.Services;
using Smartclean.core.Sharing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartclean.infrastructure.Repositories
{
    public class AuthRepository : IAuth
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IGenerateToken _generateToken;

        public AuthRepository(UserManager<AppUser> userManager, IEmailService emailService, SignInManager<AppUser> signInManager, IGenerateToken generateToken)
        {
            _userManager = userManager;
            _emailService = emailService;
            _signInManager = signInManager;
            _generateToken = generateToken;
        }
        public async Task<string> RegisterAsync(RegisterDTO registerDTO)
        {
            if(registerDTO == null)
                return null;

            if (await _userManager.FindByNameAsync(registerDTO.Name) != null)
                return "Name already exists";

            if(await _userManager.FindByEmailAsync(registerDTO.Email) != null)
                return "Email already exists";

            AppUser user = new AppUser()
            {
                UserName = registerDTO.UserName,
                Name = registerDTO.Name,
                Email = registerDTO.Email
            };
            var result= await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                return result.Errors.ToList()[0].Description;
            }
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            await SendEmail(user.Email, token, "activ", "Active Acount", "Pleas active your E-Mail, Click on Button to Active");
            return "Registration successful";
        }

        public async Task SendEmail(string email, string code, string component, string subject, string message) 
        {
            var result = new EmailDTO(email, "Moatazyazan86@gmail.com", subject,
                EmailStringBody.send(email, code, component, message));
            await _emailService.SendEmail(result);
        }

        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            if (loginDTO == null)
                return null;

            var findUser = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (!findUser.EmailConfirmed)
            {
                string token = await _userManager.GenerateEmailConfirmationTokenAsync(findUser);
                await SendEmail(findUser.Email, token, "activ", "Active Acount", "Pleas active your E-Mail, Click on Button to Active");
                return "please confirm your email first, we have sent activat email";
            }

            var result = await _signInManager.PasswordSignInAsync(findUser, loginDTO.Password, true, false);
            if (result.Succeeded)
            {
                string token = _generateToken.GetAndCreateToken(findUser);
                return token;
            }
            return "please check your email or password";
        }

        public async Task<bool> SendEmailForForgetPassword(string email) 
        {
            var findUser = await _userManager.FindByEmailAsync(email);
            if (findUser == null)
                return false;

            string token = await _userManager.GeneratePasswordResetTokenAsync(findUser);
            await SendEmail(findUser.Email, token, "reset", "Reset Password", "Pleas reset your password, Click on Button to Reset");
            return true;
        }

        public async Task<string> ResetPasswort(ResetPasswordDTO resetPasswordDTO)
        {
            var findUser = await _userManager.FindByEmailAsync(resetPasswordDTO.Email);
            if (findUser == null)
                return "User not found";

            var result = await _userManager.ResetPasswordAsync(findUser, resetPasswordDTO.Token, resetPasswordDTO.Password);
            if (!result.Succeeded)
            {
                return result.Errors.ToList()[0].Description;
            }
            return "Password reset successful";
        }

        public async Task<bool> ActiveAccount(ActiveAcountDTO activeAcountDTO)
        {
            var findUser = await _userManager.FindByEmailAsync(activeAcountDTO.Email);
            if (findUser == null)
                return false;

            var result = await _userManager.ConfirmEmailAsync(findUser, activeAcountDTO.Token);
            if (result.Succeeded)
                return true;
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(findUser);
            await SendEmail(findUser.Email, token, "active", "ActiveEmail", "Pleas active your email, Click on Button to Actived");
            return false;
        }
    }
}
