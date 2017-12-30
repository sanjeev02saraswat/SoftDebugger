using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackageBusinessModel.Models
{
    public class PackageDetails
    {
        public string CompanyID { get; set; }
        public BasicPackageDetails BasicPackageDetails { get; set; }

        public BasicPackageCreteria BasicPackageCreteria { get; set; }
    }
    public class BasicPackageDetails
    {
        public string PackageCode { get; set; }

        public string PackageName { get; set; }

        public string PackageLanguage { get; set; }

        public string PackageTitle { get; set; }

        public string SupplierRef { get; set; }

        public int PackageDuration { get; set; }

        public string PackageMarket { get; set; }

        public string PackageSupplier { get; set; }

        public string PackageType { get; set; }

    }

    public class BasicPackageCreteria
    {
        public string PackageMarket { get; set; }

        public string PackageSaleMarket { get; set; }

        public string PackageValidityStartDate { get; set; }

        public string PackageValidityEndDate { get; set; }

        public string PackageBookingStartDate { get; set; }

        public string PackageBookingEndDate { get; set; }

        public int PackageDuration { get; set; }

        public int ChildMinAge { get; set; }

        public int ChildMaxAge { get; set; }

        public int PackageLastPaymentDue { get; set; }

        public int PackagePaymentCutOffDay { get; set; }

        public string DiscountonFullPayment { get; set; }
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

    public class PackageImages
    {
        public string PackageCode { get; set; }
        public string CompanyID { get; set; }
        public string PackageImageName { get; set; }

        public string PackageImageTitle { get; set; }
        public string Browser { get; set; }

        public string OriginalImagePath { get; set; }

    }

    public class PackageList
    {
        public string PackageCode { get; set; }

        public string PackageName { get; set; }

        public string CompanyID { get; set; }

        public string PackageLanguage { get; set; }

        public string query { get; set; }
    }

}