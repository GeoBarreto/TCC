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
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["TEE"].ToString());
            return con;
        }
    }
}
