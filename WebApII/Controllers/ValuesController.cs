using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApII.Models;
using WebApII.Validations;

namespace WebApII.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        public void Post([FromBody]PostRequest value)
        {
        }


        [HttpPost]
        [Route("CustomerInvoice")]
        public IEnumerable<CustomerInvoice> GetCustomerInvoice(CustomerInvoiceRequest request)
        { 


            using (var unitOfWork = new UnitOfWork(new DatabaseContext()))
            {
                var r = unitOfWork
                     .Customers
                     .GetCustomerInvoice(request.Email,
                     request.InvoiceId).ToList();
                return r;
            }
        }


        [HttpPost]
        [Route("AddCustomer")]
        public  AddCustomerResponse AddCustomer(Customer customer)
        {
            var validator = new CustomerValidator();
            var results = validator.Validate(customer);


            if (results.IsValid==false)
            {
                var messages = new List<string>();
                foreach(var item in results.Errors)
                {
                    messages.Add(item.ErrorCode);
                }

                return new AddCustomerResponse()
                {
                    ErrorMessage = messages,
                    Status = false
                };
            }


            using (var unitOfWork =
                new UnitOfWork(new DatabaseContext()))
            {
                unitOfWork.Customers.Add(customer);
                unitOfWork.Complete();
            }
            return new AddCustomerResponse{ Status = true};
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<GetCustomerDTO>GetAll()
        {
            using (var unitOfWork =
               new UnitOfWork(new DatabaseContext()))
            {
                var listCustomer = unitOfWork.Customers.GetAll();

                var dtoList = new List<GetCustomerDTO>();
                foreach (var item in listCustomer)
                {
                    var dto = new GetCustomerDTO(item);
                    dtoList.Add(dto);
                }

                return dtoList;
            }

        }

        [HttpGet]
        [Route("GetAllStudents")]

        public IEnumerable<GetStudentDTO> GetAllStudents()
        {
            using (var unitOfWork =
               new UnitOfWork(new DatabaseContext()))
            {
                var listStudent = unitOfWork.Students.GetAll();

                var dtoList = new List<GetStudentDTO>();
                foreach (var item in listStudent)
                {
                    var dto = new GetStudentDTO(item);
                    dtoList.Add(dto);
                }

                return dtoList;
            }

        }


        [HttpPost]
        [Route("AddStudent")]

        public AddStudentResponse AddStudent(Student student)
        {
            var validator = new StudentValidator();
            var results = validator.Validate(student);


            if (results.IsValid == false)
            {
                var messages = new List<string>();
                foreach (var item in results.Errors)
                {
                    messages.Add(item.ErrorMessage);
                }

                return new AddStudentResponse()
                {
                    ErrorMessage = messages,
                    Status = false
                };
            }


            using (var unitOfWork =
                new UnitOfWork(new DatabaseContext()))
            {
                unitOfWork.Students.Add(student);
                unitOfWork.Complete();
            }
            return new AddStudentResponse { Status = true };
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
    public class PostRequest
    {
        public string Value { get; set; }
        public string Value2 { get; set; }
    }
}
