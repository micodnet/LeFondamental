using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox
{
    public interface IConnection
    {
        int ExecuteNonQuery(Command command);
        IEnumerable<TResult> ExecuteReader<TResult>(Command command, Func<IDataRecord, TResult> selector);
        object ExecuteScalar(Command command);
    }
}
