using System.Collections.Generic;

namespace Wirtualnik.Data.Models
{
    public class Category : EntityBase
    {
        public string Name { get; set; } = "";
        public string PublicId { get; set; } = "";

        public virtual ICollection<CategoryProperty> CategoryProperties { get; set; } = null!;
    }
}