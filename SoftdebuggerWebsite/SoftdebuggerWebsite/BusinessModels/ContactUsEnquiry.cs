using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftdebuggerWebsite.BusinessModels
{
    public class ContactUsEnquiry
    {
        public string CustomerName { get; set; }

        public string CustomerMobile { get; set; }

        public string CustomerCompany { get; set; }

        public string PopupISD { get; set; }

        public string Country { get; set; }

        public string CustomerMessage { get; set; }

        public string QueryType { get; set;   }

        public string Email { get; set; }
    }
}
