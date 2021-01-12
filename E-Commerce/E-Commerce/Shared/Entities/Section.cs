using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Entities
{
    public class Section : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<Category> Categories { get; set; }


    }
}
