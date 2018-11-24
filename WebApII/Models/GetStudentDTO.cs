using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApII.Models
{
    public class GetStudentDTO
    {
        public GetStudentDTO(Student student)
        {
            StudentId = student.StudentId;
            FullName = $"{student.FirstName},{student.LastName}";
            Address=student.Address;
        }

        public int StudentId { get; }
        public string FullName { get; }
        public string Address { get; }
    }
}