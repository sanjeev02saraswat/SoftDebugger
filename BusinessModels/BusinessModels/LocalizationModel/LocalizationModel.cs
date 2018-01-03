using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.LocalizationModel
{
   public class LocalizationModel
    {
        public string ApplicationName { get; set; }

        public string ApplicationID { get; set; }

        public string PageID { get; set; }

        public string PageName { get; set; }

        public string LanguageCode { get; set; }

        public string ResourceID { get; set; }

        public string ResourceValue { get; set; }

        public string CompanyID { get; set; }
    }
}
