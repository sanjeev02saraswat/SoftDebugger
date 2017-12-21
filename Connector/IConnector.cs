using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorAPI
{
   public interface IConnector
    {
        bool ExecuteNonQuery(string ConnectionStringName,string StoredProcedureName,Dictionary<string,object> Parameters =null);

        DataTable ExecuteDataTable(string ConnectionStringName, string StoredProcedureName, Dictionary<string, object> Parameters = null);


        object  ExecuteScalar(string ConnectionStringName, string StoredProcedureName, Dictionary<string, object> Parameters = null);
    }
}
