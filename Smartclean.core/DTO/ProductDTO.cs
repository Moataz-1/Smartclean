using Microsoft.AspNetCore.Http;
using Smartclean.core.Entities.Product;
using System.ComponentModel.DataAnnotations.Schema;


namespace Smartclean.core.DTO
{
    public record ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public List<PhotoDTO> Photos { get; set; }
        public string CategoryName { get; set; }
    }
    public record PhotoDTO
    {
        public string ImageName { get; set; }
        public int ProductId { get; set; }
    }
    public record AddProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public int CategoryId { get; set; }
        public IFormFileCollection Photo { get; set; }
    }
    public record UpdateProductDTO : AddProductDTO
    {
        public int id { get; set; }
    }
}
