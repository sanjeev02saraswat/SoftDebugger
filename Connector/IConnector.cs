using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorAPI
{
   public interface IConnector
    {
        bool ExecuteNonQuery(string ConnectionStringName,string StoredProcedureName,Dictionary<string,object> Parameters =null);
    }
}
