using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Script.Serialization;

namespace WEBAPI2.Utilities
{
    public class CommonUtility
    {

        /// <summary>
        /// There is restriction for creating object of this class.It is one utility.
        /// </summary>
        private CommonUtility()
        {
        }
        internal static HttpResponseMessage CreateResponse(HttpStatusCode statusCode, object result = null)
        {
            return new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = result != null
                    ? new ObjectContent(result.GetType(), result, new JsonMediaTypeFormatter
                    {
                        SerializerSettings =
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        },
                        Indent = true
                    })
                    : null
            };
        }


        internal static string GetDataTableToJSON(DataTable dtPackageList)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dtPackageList.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtPackageList.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            string JSONResult = jsSerializer.Serialize(parentRow);
            return JSONResult;
        }

        public static string DataSettoJSON(DataSet ds)
        {
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
        }

    }
}


