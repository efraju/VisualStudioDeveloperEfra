using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class CustomerInvoiceRequest
    {
        public string Email { get; set; }
        public int InvoiceId { get; set; }
    }
}
