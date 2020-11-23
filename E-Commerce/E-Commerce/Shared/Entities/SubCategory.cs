using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Entities
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int? CategoryId { get; set; }
    }
}
