using Microsoft.AspNetCore.Http;

namespace Smartclean.core.Services
{
    public interface IImageManagementService
    {
        Task<List<string>>AddImageAsync(IFormFileCollection files, string src)
    }
}
