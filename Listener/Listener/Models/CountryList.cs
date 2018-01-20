using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI2.Models
{
    public class LanguageList
    {
        public string LanguageCode { get; set; }

        public string LanguageName { get; set; }

        public string nativeLanguageName { get; set; }
    }

    public class CurrencyList
    {
        public string CurrencyCode { get; set; }

        public string CurrencyName { get; set; }

        public string CurrencySymbol { get; set; }
    }

    public class CountryList
    {
        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        
    }

    public class Signupuser
    {
        public string Language { get; set; }

        public string DefaultPage { get; set; }
        public string CultureCode { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string CompanyID { get; set; }

        public string Tokenid { get; set; }

        public string EmployeeID { get; set; }

        public string Mobile { get; set; }

        public bool LoginStatus { get; set; }
    }


}

