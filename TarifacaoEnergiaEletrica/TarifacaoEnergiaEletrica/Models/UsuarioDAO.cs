using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TarifacaoEnergiaEletrica.Models
{
    class UsuarioDAO
    {
        private static UsuarioDAO instancia;
        private SqlConnection con;
        private SqlCommand cmd;
        //parametros
        public String prm_Email;
        public String prm_IdCliente;
        public String prm_CPF;
        public String prm_Nome;
        public String prm_Senha;
        public String prm_Ativo;
        public String prm_Tipo;
        public String prm_DataRegistro;

        //campos
        public String cp_Email;
        public String cp_IdCliente;
        public String cp_CPF;
        public String cp_Nome;
        public String cp_Senha;
        public String cp_Ativo;
        public String cp_Tipo;
        public String cp_DataRegistro;

        public UsuarioDAO()
        {
            prm_Email = "@EMAIL";
            prm_IdCliente = "@ID_CLIENTE";
            prm_CPF = "@CPF";
            prm_Nome = "@NOME";
            prm_Senha = "@SENHA";
            prm_Ativo = "@ATIVO";
            prm_Tipo = "@TIPO";
            prm_DataRegistro = "@DATA_REGISTRO";

            cp_Email = "email";
            cp_IdCliente = "id_cliente";
            cp_CPF = "cpf";
            cp_Nome = "nome";
            cp_Senha = "senha";
            cp_Ativo = "ativo";
            cp_Tipo = "tipo";
            cp_DataRegistro = "data_registro";
        }

        public static UsuarioDAO ObterInstancia()
        {
            if (instancia == null)
            {
                instancia = new UsuarioDAO();
            }

            return instancia;
        }

        public Usuario Login(String email, String senha)
        {
            //String procNome = "sp_GerenciaUsuario";
            String procNome = "SELECT * FROM usuarios WHERE " + cp_Email + " = " + prm_Email + " AND " + cp_Senha + " = " + prm_Senha + " AND ativo = 'true';";


            Usuario u = new Usuario(); ;

            if (email != null && senha != null)
            {
                using (con = ConexaoBD.ObterConexao())
                {
                    cmd = new SqlCommand(procNome, con);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandType = System.Data.CommandType.Text;
                    //cmd.Parameters.AddWithValue("@FUNCAO", "1");
                    cmd.Parameters.Add(prm_Email, SqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add(prm_Senha, SqlDbType.VarChar).Value = senha;

                    con.Open();
                    SqlDataReader resultado = cmd.ExecuteReader();
                    if (resultado.Read())
                    {
                        using (resultado)
                        {
                            //u.Email = resultado.GetString(resultado.GetOrdinal(cp_Email));
                            u.IdCliente = resultado.GetInt32(resultado.GetOrdinal(cp_IdCliente));
                            //u.CPF = resultado.GetString(resultado.GetOrdinal(cp_CPF));
                            u.Nome = resultado.GetString(resultado.GetOrdinal(cp_Nome));
                            //u.Senha = resultado.GetString(resultado.GetOrdinal(cp_Senha));
                            //u.Ativo = resultado.GetBoolean(resultado.GetOrdinal(cp_Ativo));
                            //u.Tipo = resultado.GetInt32(resultado.GetOrdinal(cp_Tipo));
                            //u.DataRegistro = resultado.GetDateTime(resultado.GetOrdinal(cp_DataRegistro));
                        }
                    }
                    else
                    {
                        u = null;
                    }
                }
            }
            else
            {
                u = null;
            }
            return u;

        }

        public int AtualizaUsuario(Usuario u)
        {
            SqlParameter parametroSaida;
            String procNome = "sp_GerenciaUsuario";
            int status = 0;

            using (con = ConexaoBD.ObterConexao())
            {
                cmd = new SqlCommand(procNome, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FUNCAO", "2");
                cmd.Parameters.AddWithValue(prm_Email, u.Email);
                cmd.Parameters.AddWithValue(prm_IdCliente, u.IdCliente);
                cmd.Parameters.AddWithValue(prm_CPF, u.CPF);
                cmd.Parameters.AddWithValue(prm_Nome, u.Nome);
                cmd.Parameters.AddWithValue(prm_Senha, u.Senha);
                cmd.Parameters.AddWithValue(prm_Ativo, u.Ativo);
                cmd.Parameters.AddWithValue(prm_Tipo, u.Tipo);
                cmd.Parameters.AddWithValue(prm_DataRegistro, u.DataRegistro);

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

        public int SalvarUsuario(Usuario u)
        {
            SqlParameter parametroSaida;
            String procNome = "sp_GerenciaUsuario";
            int status = 0;

            using (con = ConexaoBD.ObterConexao())
            {
                cmd = new SqlCommand(procNome, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FUNCAO", "3");
                cmd.Parameters.AddWithValue(prm_Email, u.Email);
                cmd.Parameters.AddWithValue(prm_IdCliente, u.IdCliente);
                cmd.Parameters.AddWithValue(prm_CPF, u.CPF);
                cmd.Parameters.AddWithValue(prm_Nome, u.Nome);
                cmd.Parameters.AddWithValue(prm_Senha, u.Senha);
                cmd.Parameters.AddWithValue(prm_Ativo, u.Ativo);
                cmd.Parameters.AddWithValue(prm_Tipo, u.Tipo);
                cmd.Parameters.AddWithValue(prm_DataRegistro, u.DataRegistro);

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

        public void DesativarUsuario(String Email)
        {
            String sql = "UPDATE usuarios SET Ativo = False WHERE " + cp_Email + " = " + prm_Email;

            using (con = ConexaoBD.ObterConexao())
            {
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue(prm_Email, Email);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
    }
}
