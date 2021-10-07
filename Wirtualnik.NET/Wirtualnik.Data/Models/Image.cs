﻿namespace Wirtualnik.Data.Models
{
    public class Image : EntityBase
    {
        public string FileName { get; set; } = "";
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Main { get; set; }
    }
}