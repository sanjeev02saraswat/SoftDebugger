using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI2.Models
{
    public class CountryList
    {
        public string code { get; set; }

        public string name { get; set; }

        public string dial_code { get; set; }
    }

    public class Signupuser
    {
        public string CultureCode { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }
    }


}

