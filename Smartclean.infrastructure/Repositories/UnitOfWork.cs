using AutoMapper;
using Smartclean.core.Interfaces;
using Smartclean.core.Services;
using Smartclean.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartclean.infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageManagementService _imageManagementService;

        

        public ICategoryRepositry CategoryRepositry { get; }
        public IPhotoRepositry PhotoRepositry { get; }
        public IProductRepositry ProductRepositry { get; }

        public UnitOfWork(AppDbContext context, IMapper mapper ,IImageManagementService imageManagementService)
        {
            _context = context;
            _mapper = mapper;
            _imageManagementService = imageManagementService;

            CategoryRepositry = new CategoryRepositry(context);
            PhotoRepositry = new PhotoRepositry(context);
            ProductRepositry = new ProductRepositry(context, _mapper,_imageManagementService);
            
        }
    }
}
