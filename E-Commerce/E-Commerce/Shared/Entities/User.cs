using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Entities
{
    public class User : IdentityUser<string>
    {
        [ForeignKey("UserInformationsId")]
        public UserInformations UserInformations { get; set; }
        public int UserInformationsId { get; set; }
    }
}
