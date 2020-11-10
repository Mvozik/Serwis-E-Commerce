using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Dtos.ProductDtos
{
    public class OperationFailedResponse
    {
       public IEnumerable<string> Errors { get; set; }
        
    }
}
