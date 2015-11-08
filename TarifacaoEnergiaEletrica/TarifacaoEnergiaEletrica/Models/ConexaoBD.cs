using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace TarifacaoEnergiaEletrica.Models
{
    class ConexaoBD
    {
        protected static SqlConnection con;

        public static SqlConnection ObterConexao()
        {
            if (con == null)
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["STEL"].ToString());
            }
            return con;
        }
    }
}
