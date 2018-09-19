using PattuSaree.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Data.Infrastructure
{
    public interface ISqlHelper
    {
        IEnumerable<T> ExecStoredProcedure<T>(string name, List<SqlParameterViewModel> parameters = null);
        int ExecStoredProcedureWithOutResult(string name, List<SqlParameterViewModel> parameters = null);
    }
}
