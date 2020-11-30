using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Dtos
{
    public class PutUserInformationsDto
    {
        
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
