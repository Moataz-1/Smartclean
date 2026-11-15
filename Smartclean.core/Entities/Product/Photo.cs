using System.ComponentModel.DataAnnotations.Schema;

namespace Smartclean.core.Entities.Product
{
    public class Photo : BaseEntity
    {
        public string ImageName { get; set; }
        public int ProductId { get; set; }
    }
}
