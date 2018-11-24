using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccess.Repositories
{
    public class CustomerRepository:Repository<Customer>,ICustomerRepositorie
    {

        public CustomerRepository(
            DatabaseContext contex):base(contex)
        {

        }

        public IEnumerable<CustomerInvoice> GetCustomerInvoice(string email,int invoiceId)
        {
            var customerEmail = new SqlParameter("@email",email);
            var customerInvoiceId = new SqlParameter("@invoiceId", invoiceId);

            //return Context.Database.SqlQuery<CustomerInvoice>
            //    ("CustomerInvoice @email @invoiceId",
            //    customerEmail, customerInvoiceId);

            return new List<CustomerInvoice>()
            {
                new CustomerInvoice(){Email="test",Total=2},
                new CustomerInvoice(){Email="test2",Total=3}
            };

        }
    } 
}
