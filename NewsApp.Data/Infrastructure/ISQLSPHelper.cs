using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Data.Infrastructure
{
    public interface ISQLSPHelper
    {
        void BulkInsert<T>(string connectionString, string tableName, IList<T> list);
        void BulkUpdate<T>(string connectionString, string tableName, IEnumerable<T> list, string primaryKeyColumnName, params string[] propertiesToUpdate);
        void ExecStoredProcedureWithoutResults(string name, Dictionary<string, string> parameters);
        IEnumerable<T> ExecStoredProcedureWithResults<T>(string name, Dictionary<string, string> parameters = null);
        //IEnumerable<T> ExecStoredProcedureWithResults<T>(string name, Dictionary<string, dynamic> parameters = null);
        IEnumerable<T> ExecStoredProcedureWithReturnValue<T>(string name, string queryParams, object[] parameters);
        IEnumerable<T> ExecStoredProcedureWithReturnValueSingleParam<T>(string name, string queryParams);
        IEnumerable<T> ExecSqlWithResults<T>(string sql);
        int ExecSqlWithoutResultsWithParam(string name, string queryParams);
        int ExecSqlWithoutResults(string sql);
        IEnumerable<T> ExecStoredProcedureWithDynamicParams<T>(string name, Dictionary<string, dynamic> parameters = null);
    }
}
