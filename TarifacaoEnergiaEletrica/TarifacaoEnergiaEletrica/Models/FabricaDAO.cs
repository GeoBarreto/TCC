using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace TarifacaoEnergiaEletrica.Models
{
    class FabricaDAO
    {
        private static FabricaDAO instancia;
        private SqlConnection con;
        private SqlCommand cmd;
        //parametros
        private String prm_IdFabrica;
        private String prm_IdCliente;
        private String prm_CNPJ;
        private String prm_Endereco;
        private String prm_IdDistribuidora;
        //campos
        private String cp_IdFabrica;
        private String cp_IdCliente;
        private String cp_CNPJ;
        private String cp_Endereco;
        private String cp_IdDistribuidora;

        public FabricaDAO()
        {
            prm_IdFabrica = "@ID_FABRICA";
            prm_IdCliente = "@ID_CLIENTE";
            prm_CNPJ = "@CNPJ";
            prm_Endereco = "@ENDERECO";
            prm_IdDistribuidora = "@ID_DISTRIBUIDORA";

            cp_IdFabrica = "id_fabrica";
            cp_IdCliente = "id_cliente";
            cp_CNPJ = "cnpj_fabrica";
            cp_Endereco = "endereco";
            cp_IdDistribuidora = "id_distribuidora";
        }

        public static FabricaDAO ObterInstancia()
        {
            if (instancia == null)
            {
                instancia = new FabricaDAO();
            }

            return instancia;
        }

        public Fabrica ObterFabricaPorID(int idFabrica)
        {
            String procNome = "sp_GerenciaFabrica";
            Fabrica f = new Fabrica();

            using (con = ConexaoBD.ObterConexao())
            {
                cmd = new SqlCommand(procNome, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FUNCAO", "1");
                cmd.Parameters.AddWithValue(prm_IdFabrica, idFabrica);


                con.Open();
                using (SqlDataReader resultado = cmd.ExecuteReader())
                {
                    f.IdFabrica = resultado.GetInt32(resultado.GetOrdinal(cp_IdFabrica));
                    f.IdCliente = resultado.GetInt32(resultado.GetOrdinal(cp_IdCliente));
                    f.CNPJ = resultado.GetString(resultado.GetOrdinal(cp_CNPJ));
                    f.Endereco = resultado.GetString(resultado.GetOrdinal(cp_Endereco));
                }
            }

            return f;

        }

        public int AtualizaFabrica(Fabrica f)
        {
            SqlParameter parametroSaida;
            String procNome = "sp_GerenciaFabrica";
            int status = 0;

            using (con = ConexaoBD.ObterConexao())
            {
                cmd = new SqlCommand(procNome, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FUNCAO", "2");
                cmd.Parameters.AddWithValue(prm_IdFabrica, f.IdFabrica);
                cmd.Parameters.AddWithValue(prm_IdCliente, f.IdCliente);
                cmd.Parameters.AddWithValue(prm_CNPJ, f.CNPJ);
                cmd.Parameters.AddWithValue(prm_Endereco, f.Endereco);

                parametroSaida = new SqlParameter();
                parametroSaida.ParameterName = "@STATUS";
                parametroSaida.SqlDbType = System.Data.SqlDbType.Int;
                parametroSaida.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametroSaida);

                con.Open();
                cmd.ExecuteNonQuery();

                status = Convert.ToInt32(parametroSaida.Value);

            }

            return status;
        }

        public int SalvarFabrica(Fabrica f)
        {
            SqlParameter parametroSaida;
            //String procNome = "sp_GerenciaFabrica";
            String procNome = "INSERT INTO fabricas (" +
                                 cp_CNPJ + "," +
                                 cp_Endereco + "," +
                                 cp_IdCliente + "," +
                                 cp_IdDistribuidora + ")" +
                                 " Values (" +
                                 prm_CNPJ + "," +
                                 prm_Endereco + "," +
                                 prm_IdCliente + "," +
                                 prm_IdDistribuidora + ");";
            int status = 0;

            using (con = ConexaoBD.ObterConexao())
            {
                cmd = new SqlCommand(procNome, con);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandType = System.Data.CommandType.Text;

                //cmd.Parameters.AddWithValue("@FUNCAO", "3");
                cmd.Parameters.Add(prm_IdCliente, SqlDbType.Int).Value = f.IdCliente;
                cmd.Parameters.Add(prm_CNPJ, SqlDbType.VarChar).Value = f.CNPJ;
                cmd.Parameters.Add(prm_Endereco, SqlDbType.VarChar).Value = f.Endereco;
                cmd.Parameters.Add(prm_IdDistribuidora, SqlDbType.Int).Value = f.IdDistribuidora;

                //parametroSaida = new SqlParameter();
                //parametroSaida.ParameterName = "@STATUS";
                //parametroSaida.SqlDbType = System.Data.SqlDbType.Int;
                //parametroSaida.Direction = System.Data.ParameterDirection.Output;
                //cmd.Parameters.Add(parametroSaida);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();

                    status = 1;
                    //status = Convert.ToInt32(parametroSaida.Value);
                }catch
                {
                    status = 0;
                }

            }

            return status;
        }

        public int ExcluirFabrica(int IdFabrica)
        {
            SqlParameter parametroSaida;
            String procNome = "sp_GerenciaFabrica";
            int status = 0;

            using (con = ConexaoBD.ObterConexao())
            {
                cmd = new SqlCommand(procNome, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FUNCAO", "4");
                cmd.Parameters.AddWithValue(prm_IdFabrica, IdFabrica);

                parametroSaida = new SqlParameter();
                parametroSaida.ParameterName = "@STATUS";
                parametroSaida.SqlDbType = System.Data.SqlDbType.Int;
                parametroSaida.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametroSaida);

                con.Open();
                cmd.ExecuteNonQuery();

                status = Convert.ToInt32(parametroSaida.Value);

            }

            return status;
        }

        public List<Fabrica> ObterFabricasPorCliente(int IdCliente)
        {
            List<Fabrica> fabricas = new List<Fabrica>();
            //String procNome = "sp_GerenciaFabrica";
            String procNome = "SELECT * FROM fabricas WHERE " + cp_IdCliente + " = " + prm_IdCliente;
            Fabrica f;

            using (con = ConexaoBD.ObterConexao())
            {
                cmd = new SqlCommand(procNome, con);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(prm_IdCliente, SqlDbType.Int).Value = IdCliente;

                con.Open();
                using (SqlDataReader resultado = cmd.ExecuteReader())
                {
                    while (resultado.Read())
                    {
                        f = new Fabrica();

                        f.IdFabrica = resultado.GetInt32(resultado.GetOrdinal(cp_IdFabrica));
                        f.IdCliente = resultado.GetInt32(resultado.GetOrdinal(cp_IdCliente));
                        f.CNPJ = resultado.GetString(resultado.GetOrdinal(cp_CNPJ));
                        f.Endereco = resultado.GetString(resultado.GetOrdinal(cp_Endereco));

                        fabricas.Add(f);
                    }
                }
            }

            return fabricas;

        }

    }
}
