using Smartclean.core.Interfaces;
using Smartclean.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartclean.infrastructure.Repositries
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ICategoryRepositry CategoryRepositry { get; }
        public IPhotoRepositry PhotoRepositry { get; }
        public IProductRepositry ProductRepositry { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CategoryRepositry = new CategoryRepositry(context);
            PhotoRepositry = new PhotoRepositry(context);
            ProductRepositry = new ProductRepositry(context);
        }
    }
}
