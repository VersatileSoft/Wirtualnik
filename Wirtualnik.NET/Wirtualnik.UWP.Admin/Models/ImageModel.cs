using System.IO;
using Windows.UI.Xaml.Media;

namespace Wirtualnik.UWP.Admin.Models
{
    public class ImageModel
    {
        public ImageModel()
        {
        }

        public ImageModel(string name, string path, string resolution, Stream imageStream, ImageSource source)
        {
            Name = name;
            Path = path;
            Resolution = resolution;
            ImageStream = imageStream;
            Source = source;
        }

        public string Name { get; set; }
        public string Path { get; set; }
        public string Resolution { get; set; }

        public Stream ImageStream { get; set; }
        public ImageSource Source { get; set; }
    }
}
