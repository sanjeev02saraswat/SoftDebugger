using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.AdminManagement
{
  public class AgentProfile
    {
        [Required]
        public string TokenID { get; set; }

        [Required]
        [MaxLength(2)]
        public string CompanyID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(5)]
        public string Language { get; set; }

        /// <summary>
        /// We have to create one table contains some list of required default page taht will open after login
        /// </summary>
        ///
        [Required]
        public string DefaultPage { get; set; }

       
        //agent will specified for any one process
        public string Process { get; set; }

        [Required]
        public string Address { get; set; }


        public string ProfileImageLink { get; set; }

        [Required]
        [MaxLength(2)]
        public string Country { get; set; }

        [Required]
        [MaxLength(12)]
        [MinLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        
        public bool IsPhonePrivate { get; set; }

    
        public bool IsAddressPrivate { get; set; }


    }
}
