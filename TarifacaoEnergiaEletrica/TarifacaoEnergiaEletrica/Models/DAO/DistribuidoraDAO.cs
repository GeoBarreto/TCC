using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TarifacaoEnergiaEletrica.Models
{
    class DistribuidoraDAO
    {
        private static DistribuidoraDAO instancia;
        private SqlConnection con;
        private SqlCommand cmd;
        //campos
        private String cp_IdDistribuidora;
        private String cp_Nome;

        public DistribuidoraDAO()
        {
            cp_IdDistribuidora = "id_distribuidora";
            cp_Nome = "nome";
        }

        public static DistribuidoraDAO ObterInstancia()
        {
            if (instancia == null)
            {
                instancia = new DistribuidoraDAO();
            }

            return instancia;
        }

        public IEnumerable<Distribuidora> ObterDistribuidoras()
        {
            List<Distribuidora> distribuidoras = new List<Distribuidora>();
            //String procNome = "sp_GerenciaFabrica";
            String procNome = "SELECT * FROM distribuidoras";
            Distribuidora d;

            using (con = ConexaoBD.ObterConexao())
            {
                cmd = new SqlCommand(procNome, con);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandType = System.Data.CommandType.Text;

                con.Open();
                using (SqlDataReader resultado = cmd.ExecuteReader())
                {
                    while (resultado.Read())
                    {
                        d = new Distribuidora();

                        d.IdDistribuidora = resultado.GetInt32(resultado.GetOrdinal(cp_IdDistribuidora));
                        d.Nome = resultado.GetString(resultado.GetOrdinal(cp_Nome));

                        distribuidoras.Add(d);
                    }
                }
            }

            return distribuidoras;

        }
    }
}
