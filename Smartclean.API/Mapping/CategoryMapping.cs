using AutoMapper;
using Smartclean.core.DTO;
using Smartclean.core.Entities.Product;

namespace Smartclean.API.Mapping
{
    public class CategoryMapping: Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
        }
    }
}
