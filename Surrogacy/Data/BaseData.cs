using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surrogacy.Data
{
    public class BaseData
    {
        protected SqlConnection sqlConnection = null;
        protected SqlDataAdapter sqlDataAdapter = null;
        protected SqlCommand sqlCommand = null;

        protected BaseData()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SurrogacyDBConnection"].ConnectionString.ToString());
            sqlDataAdapter = new SqlDataAdapter();
        }
    }
}
