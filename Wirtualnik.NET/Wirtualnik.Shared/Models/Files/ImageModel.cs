using System;
using System.Collections.Generic;
using System.Text;

namespace Wirtualnik.Shared.Models.Files
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string FileName { get; set; } = "";
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Main { get; set; }
    }
}
