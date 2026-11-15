using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Smartclean.core.Services;

namespace Smartclean.infrastructure.Repositries.Service
{
    public class ImageManagementService : IImageManagementService
    {
        private readonly IFileProvider
        public ImageManagementService()
        {
            
        }
        public Task<List<string>> AddImageAsync(IFormFileCollection files, string src)
        {
            throw new NotImplementedException();
        }

        public Task DeleteImageAsync(string src)
        {
            throw new NotImplementedException();
        }
    }
}
