using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
   public interface ICustomerRepositorie:IRepository<Customer>
    {
          IEnumerable<CustomerInvoice> GetCustomerInvoice(string email, int invoiceId);
    }
}
