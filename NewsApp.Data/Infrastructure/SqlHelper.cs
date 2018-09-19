using PattuSaree.Data.DbContext;
using PattuSaree.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Data.Infrastructure
{
    public class SqlHelper:ISqlHelper
    {
        private PattuSareeContext _dataContext;

        #region Properties
        /// <summary>
        /// Gets the database factory.
        /// </summary>
        /// <value>The database factory.</value>
        protected IDbFactory DbFactory
        {
            get;
        }

        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>The database context.</value>
        protected PattuSareeContext DbContext => _dataContext ?? (_dataContext = DbFactory.Init());

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlspHelper"/> class.
        /// </summary>
        /// <param name="dbFactory">The database factory.</param>
        public SqlHelper(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
        #endregion

        public IEnumerable<T> ExecStoredProcedure<T>(string name, List<SqlParameterViewModel> parameters = null)
        {
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NewsApp"].ConnectionString);
            cn.Open();
            var cmd = new SqlCommand(name, cn) { CommandType = CommandType.StoredProcedure };
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    var param1 = new SqlParameter
                    {
                        SqlDbType = parameter.ParamsType,
                        ParameterName = parameter.ParamName,
                        Value = parameter.ParamsValue
                    };
                    cmd.Parameters.Add(param1);
                }
            }

            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            var result = (from DataRow row in dt.Rows select GetRow<T>(row)).ToList();
            cn.Close();
            da.Dispose();
            return result;
        }



        private static T GetRow<T>(DataRow dr)
        {

            var temp = typeof(T);
            var obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (var pro in temp.GetProperties())
                {
                    if (pro.Name.ToLower() == column.ColumnName.ToLower())
                    {
                        var val = dr[column.ColumnName] != DBNull.Value ? dr[column.ColumnName] : null;
                        pro.SetValue(obj, val, null);
                    }

                }
            }
            return obj;
        }
        public int ExecStoredProcedureWithOutResult(string name, List<SqlParameterViewModel> parameters = null)
        {
            var result = 0;
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NewsApp"].ConnectionString);
            cn.Open();
            var cmd = new SqlCommand(name, cn) { CommandType = CommandType.StoredProcedure };
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    //SqlParameter sw_lng = cmd.Parameters.AddWithValue(parameter.ParamName, parameter.ParamsValue);
                    //sw_lng.SqlDbType = parameter.ParamsType;
                    var param1 = new SqlParameter()
                    {
                        SqlDbType = parameter.ParamsType,
                        ParameterName = parameter.ParamName,
                        Value = parameter.ParamsValue
                    };
                    cmd.Parameters.Add(param1);
                }
            }
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            result = (int)dt.Rows[0][0];
            ////reader.
            //if (reader.HasRows)
            //{
            //     result = (int)reader["result"];
            //    //Here is the revised mapping code that maps our 
            //    //ClientEntity class to our SqlDataReader using Reflection and Generics
            //    //result = new Classes.GenericPopulator<LayerEntityViewModel>().CreateList(reader);
            //    //result = ((IObjectContextAdapter)DbContext)
            //    //   .ObjectContext
            //    //   .Translate<T>(reader).ToList();

            //    //(from n in ((IObjectContextAdapter) DbContext).ObjectContext.Translate<T>(reader) select n)\.ToList();
            //}
            cn.Close();
            return result;
        }
    }
}
