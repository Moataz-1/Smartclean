using Smartclean.core.DTO;

namespace Smartclean.core.Interfaces
{
    public interface IAuth
    {
        Task<string> RegisterAsync(RegisterDTO registerDTO);
        Task<string> LoginAsync(LoginDTO loginDTO);
        Task<bool> SendEmailForForgetPassword(string email);
        Task<string> ResetPasswort(ResetPasswordDTO resetPasswordDTO);
        Task<bool> ActiveAccount(ActiveAcountDTO activeAcountDTO);
    }
}
