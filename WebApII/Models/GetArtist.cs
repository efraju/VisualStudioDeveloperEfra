using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApII.Models
{
    public class GetArtist
    {
        public string SearchTerm { get; set; }
        public int Page { get; set; }
        public int Rows { get; set; }
    }
}