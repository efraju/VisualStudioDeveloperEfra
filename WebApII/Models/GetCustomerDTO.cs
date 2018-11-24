using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApII.Models
{
    [DataContract]
    public class GetCustomerDTO
    {
        public GetCustomerDTO(Customer customer)
        {
            CustomerId = customer.CustomerId;
            FullName = $"{customer.FirstName},{customer.LastName}";
        }

        [DataMember]
        public int CustomerId { get; set;  }
        [DataMember]
        public string FullName { get; set; }
    }
}