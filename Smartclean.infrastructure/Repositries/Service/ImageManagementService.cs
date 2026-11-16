using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Smartclean.core.Services;

namespace Smartclean.infrastructure.Repositries.Service
{
    public class ImageManagementService : IImageManagementService
    {
        private readonly IFileProvider fileProvider;

        public ImageManagementService(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }
        public async Task<List<string>> AddImageAsync(IFormFileCollection files, string src)
        {
            var SaveImageSrc = new List<string>();
            var ImageDirctory = Path.Combine("wwwroot", "Image", src);
            if (Directory.Exists(ImageDirctory) is not true)
            {
                Directory.CreateDirectory(ImageDirctory);
            }
            foreach (var file in files) 
            {
                if(file.Length > 0)
                {
                    var ImageName = file.FileName;
                    var ImageSrc = $"Image/{src}/{ImageName}";
                    var root = Path.Combine(ImageDirctory, ImageName);
                    using (FileStream stream = new FileStream(root, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    SaveImageSrc.Add(ImageSrc);
                }
            }
            return SaveImageSrc;
        }

        public void DeleteImageAsync(string src)
        {
            var info = fileProvider.GetFileInfo(src);
            var root = info.PhysicalPath;
            File.Delete(root);
        }
    }
}
