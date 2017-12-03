using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Listener.Models
{
    public class PackageDetails
    {
        public string PackageCode { get; set; }

        public string PackageName { get; set; }

        public string PackageLanguage { get; set; }

        public string PackageTitle { get; set; }

        public string SupplierRef { get; set; }

        public string PackageRemarks { get; set; }

        public PackageCriteria PackageCriteria { get; set; }

    }

    public class PackageItinerary
    {
        public string MyProperty { get; set; }
    }
    public class PackageValidDays
    {
        public string ValidonMonday { get; set; }
        public string ValidonTuesday { get; set; }
        public string ValidonWednesday { get; set; }
        public string ValidonThursday { get; set; }
        public string ValidonFriday { get; set; }
        public string ValidonSaturday { get; set; }
        public string ValidonSunday { get; set; }
    }
    public class PackageCriteria
    {
        public string PackageMarket { get; set; }

        public string PackageCode { get; set; }

        public string PackageSaleMarket { get; set; }

        public string PackageValidityStartDate { get; set; }

        public string PackageValidityLastDate { get; set; }

        public string PackageBookingStartDate { get; set; }

        public string PackageBookingLastDate { get; set; }

        public PackageValidDays PackageValidDays { get; set; }

        public string PackageDuration { get; set; }

        public string ChildMinAge { get; set; }
        public string ChildMaxAge { get; set; }


        public string PackageLastPaymentDue { get; set; }

        //reminder will start from this day
        public string PackagePaymentCutOffDate { get; set; }
      
        //will be in % only
        public string Discountonfullpayment { get; set; }
    }
    
}