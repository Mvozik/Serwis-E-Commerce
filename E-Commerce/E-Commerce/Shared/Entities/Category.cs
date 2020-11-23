using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<SubCategory> SubCategories { get; set; }

        [ForeignKey("SectionId")]
        public Section Section { get; set; }
        public int? SectionId { get; set; }

    }
}
