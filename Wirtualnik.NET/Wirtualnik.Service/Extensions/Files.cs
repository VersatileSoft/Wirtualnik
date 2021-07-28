using Microsoft.AspNetCore.Http;
using System;

namespace Wirtualnik.Service.Extensions
{
    public static class Files
    {
        public static Tuple<int, int> GetImageSizeFromFile(this IFormFile file)
        {
            using (var image = System.Drawing.Image.FromStream(file.OpenReadStream()))
            {
                return new Tuple<int, int>(image.Width, image.Height);
            }
        }
    }
}
