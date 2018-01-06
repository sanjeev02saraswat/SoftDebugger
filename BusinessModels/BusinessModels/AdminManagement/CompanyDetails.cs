using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.AdminManagement
{
    /// <summary>
    /// This class will contain all the details about Company
    /// </summary>
    class CompanyDetails
    {

        [Required]
        [MaxLength(2)]
        public string CompanyID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyAddress { get; set; }
        [Required]
        [MaxLength(2)]
        public string CompanyCountry { get; set; }
        [Required]
        [MaxLength(3)]
        public string CompanyCurrency { get; set; }
        [Required]
        [MaxLength(5)]
        public string DefaultLanguage { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string CompanyEmail { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string CompanyContact { get; set; }


        [Required]
        [DataType(DataType.PostalCode)]
        public string CompanyPostalCode { get; set; }
    }
}
