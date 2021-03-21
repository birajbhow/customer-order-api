using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApi.Common.Models
{
    public class OrderRequest
    {
        public string User { get; set; }
        public string CustomerId { get; set; }
    }
}
