﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftdebuggerWebsite.BusinessModels
{
    public class ContactUsEnquiry
    {
        public string CustomerName { get; set; }

        public string CustomerMobile { get; set; }

        public string CustomerMessage { get; set; }

        public string QueryType { get; set;   }
    }
}