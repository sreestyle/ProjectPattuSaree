using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.ViewModel
{
    //For Passing Sql parameters
    public class SqlParameterViewModel
    {
        public string ParamName { get; set; }
        public SqlDbType ParamsType { get; set; }
        public dynamic ParamsValue { get; set; }
    }
}
