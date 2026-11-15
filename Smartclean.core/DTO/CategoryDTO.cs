using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartclean.core.DTO
{
    public record CategoryDTO
    (string Name, string Description);
    public record UpdateCategoryDTO
        (string Name, string Description, int id);
}
