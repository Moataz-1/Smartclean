using Smartclean.core.Entities.Product;
using Smartclean.core.Interfaces;
using Smartclean.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartclean.infrastructure.Repositries
{
    public class ProductRepositry : GenricRepositry<Product>, IProductRepositry
    {
        public ProductRepositry(AppDbContext context) : base(context)
        {
        }
    }
}
