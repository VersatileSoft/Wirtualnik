using System.Collections.Generic;

namespace Wirtualnik.Shared.Models.Category
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public IEnumerable<CategoryPropertyModel> CategoryProperties { get; set; } = new List<CategoryPropertyModel>();
        public string PublicId { get; set; } = "";
    }
}