using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApII.Models
{
    public class AddStudentResponse
    {
        public IEnumerable<string>
            ErrorMessage
        { get; set; }

        public bool Status { get; set; }
    }
}