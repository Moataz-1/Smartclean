using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Smartclean.core.Entities;
using Smartclean.core.Interfaces;
using Smartclean.core.Services;
using Smartclean.infrastructure.Data;
using StackExchange.Redis;


namespace Smartclean.infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageManagementService _imageManagementService;
        private readonly IConnectionMultiplexer redis;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IGenerateToken token;



        public ICategoryRepositry CategoryRepositry { get; }
        public IPhotoRepositry PhotoRepositry { get; }
        public IProductRepositry ProductRepositry { get; }

        public ICustomerBasketRepositry CustomerBasket { get; }

        public IAuth Auth { get; }

        public UnitOfWork(AppDbContext context, IMapper mapper, IImageManagementService imageManagementService,
            IConnectionMultiplexer redis, UserManager<AppUser> userManager,
            IEmailService emailService, SignInManager<AppUser> signInManager, IGenerateToken generateToken)
        {
            _context = context;
            _mapper = mapper;
            _imageManagementService = imageManagementService;
            this.redis = redis;
            _userManager = userManager;
            _emailService = emailService;
            _signInManager = signInManager;
            this.token = generateToken;

            CategoryRepositry = new CategoryRepositry(context);
            PhotoRepositry = new PhotoRepositry(context);
            ProductRepositry = new ProductRepositry(context, _mapper, _imageManagementService);
            CustomerBasket = new CustomerBasketRepositry(redis);
            Auth = new AuthRepository(_userManager, _emailService, _signInManager, token);
        }
    }
}
