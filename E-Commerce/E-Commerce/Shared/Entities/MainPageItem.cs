using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Entities
{
    public class MainPageItem:BaseEntity
    {
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public int Order { get; set; }
    }
}
