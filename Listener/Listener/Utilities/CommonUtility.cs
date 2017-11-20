using Newtonsoft.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;

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

    }
}


