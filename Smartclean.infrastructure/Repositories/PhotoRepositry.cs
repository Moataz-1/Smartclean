using Smartclean.core.Entities.Product;
using Smartclean.core.Interfaces;
using Smartclean.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartclean.infrastructure.Repositories
{
    public class PhotoRepositry : GenricRepositry<Photo>, IPhotoRepositry
    {
        public PhotoRepositry(AppDbContext context) : base(context)
        {
        }
    }
}
