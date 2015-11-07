﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TarifacaoEnergiaEletrica.Models
{
    class ContaDAO
    {
        private static ContaDAO instancia;
        private SqlConnection con;
        private SqlCommand cmd;
        //parametros
        private String prm_DataReferencia;
        private String prm_IdFabrica;
        private String prm_ConsumoNP;
        private String prm_ConsumoFP;
        private String prm_DemandaTUSD;
        private String prm_ConsumoUltrapassagemNP;
        private String prm_ConsumoUltrapassagemFP;
        private String prm_ConsumoUltrapassagem;
        private String prm_DataInicio;
        private String prm_DataFim;
        //campos
        private String cp_DataReferencia;
        private String cp_IdFabrica;
        private String cp_ConsumoNP;
        private String cp_ConsumoFP;
        private String cp_DemandaTUSD;
        private String cp_ConsumoUltrapassagemNP;
        private String cp_ConsumoUltrapassagemFP;
        private String cp_ConsumoUltrapassagem;

        public ContaDAO()
        {
            prm_DataReferencia = "@DATA_REFERENCIA";
            prm_IdFabrica = "ID_FABRICA";
            prm_ConsumoNP = "@CONSUMO_NP";
            prm_ConsumoFP = "@CONSUMO_FP";
            prm_DemandaTUSD = "@DEMANDA_TUSD";
            prm_ConsumoUltrapassagemNP = "@CONSUMO_ULTRAPASSAGEM_NP";
            prm_ConsumoUltrapassagemFP = "@CONSUMO_ULTRAPASSAGEM_FP";
            prm_ConsumoUltrapassagem = "@CONSUMO_ULTRAPASSAGEM";
            prm_DataInicio = "@DATA_INICIO";
            prm_DataFim = "@DATA_FIM";

            cp_DataReferencia = "data_referencia";
            cp_IdFabrica = "id_fabrica";
            cp_ConsumoNP = "consumo_np";
            cp_ConsumoFP = "consumo_fp";
            cp_DemandaTUSD = "demanda_tusd";
            cp_ConsumoUltrapassagemNP = "consumo_ultrapasagem_np";
            cp_ConsumoUltrapassagemFP = "consumo_ultrapasagem_fp";
            cp_ConsumoUltrapassagem = "consumo_ultrapasagem";
        }

        public static ContaDAO ObterInstancia()
        {
            if (instancia == null)
            {
                instancia = new ContaDAO();
            }

            return instancia;
        }



        public Conta ObterConta(DateTime dataReferencia, int idFabrica)
        {
            String procNome = "sp_GerenciaConta";
            Conta c = new Conta();

            using (con = ConexaoBD.ObterConexao())
            {
                cmd = new SqlCommand(procNome, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FUNCAO", "1");
                cmd.Parameters.AddWithValue(prm_DataReferencia, dataReferencia);
                cmd.Parameters.AddWithValue(prm_IdFabrica, idFabrica);

                con.Open();
                using (SqlDataReader resultado = cmd.ExecuteReader())
                {
                    c.DataReferencia = resultado.GetDateTime(resultado.GetOrdinal(cp_DataReferencia));
                    c.IdFabrica = resultado.GetInt32(resultado.GetOrdinal(cp_IdFabrica));
                    c.ConsumoNP = resultado.GetDouble(resultado.GetOrdinal(cp_ConsumoNP));
                    c.ConsumoFP = resultado.GetDouble(resultado.GetOrdinal(cp_ConsumoFP));
                    c.DemandaTUSD = resultado.GetDouble(resultado.GetOrdinal(cp_DemandaTUSD));
                    c.ConsumoUltrapassagemNP = resultado.GetDouble(resultado.GetOrdinal(cp_ConsumoUltrapassagemNP));
                    c.ConsumoUltrapassagemFP = resultado.GetDouble(resultado.GetOrdinal(cp_ConsumoUltrapassagemFP));
                    c.ConsumoUltrapassagem = resultado.GetDouble(resultado.GetOrdinal(cp_ConsumoUltrapassagem));
                }
            }

            return c;

        }

        public int AtualizaConta(Conta c)
        {
            SqlParameter parametroSaida;
            String procNome = "sp_GerenciaConta";
            int status = 0;

            using (con = ConexaoBD.ObterConexao())
            {
                cmd = new SqlCommand(procNome, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FUNCAO", "2");
                cmd.Parameters.AddWithValue(prm_DataReferencia, c.DataReferencia);
                cmd.Parameters.AddWithValue(prm_IdFabrica, c.IdFabrica);
                cmd.Parameters.AddWithValue(prm_ConsumoNP, c.ConsumoNP);
                cmd.Parameters.AddWithValue(prm_ConsumoFP, c.ConsumoFP);
                cmd.Parameters.AddWithValue(prm_DemandaTUSD, c.DemandaTUSD);
                cmd.Parameters.AddWithValue(prm_ConsumoUltrapassagemNP, c.ConsumoUltrapassagemNP);
                cmd.Parameters.AddWithValue(prm_ConsumoUltrapassagemFP, c.ConsumoUltrapassagemFP);
                cmd.Parameters.AddWithValue(prm_ConsumoUltrapassagem, c.ConsumoUltrapassagem);

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

        public int SalvarConta(Conta c)
        {
            SqlParameter parametroSaida;
            String procNome = "sp_GerenciaConta";
            int status = 0;

            using (con = ConexaoBD.ObterConexao())
            {
                cmd = new SqlCommand(procNome, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FUNCAO", "3");
                cmd.Parameters.AddWithValue(prm_DataReferencia, c.DataReferencia);
                cmd.Parameters.AddWithValue(prm_IdFabrica, c.IdFabrica);
                cmd.Parameters.AddWithValue(prm_ConsumoNP, c.ConsumoNP);
                cmd.Parameters.AddWithValue(prm_ConsumoFP, c.ConsumoFP);
                cmd.Parameters.AddWithValue(prm_DemandaTUSD, c.DemandaTUSD);
                cmd.Parameters.AddWithValue(prm_ConsumoUltrapassagemNP, c.ConsumoUltrapassagemNP);
                cmd.Parameters.AddWithValue(prm_ConsumoUltrapassagemFP, c.ConsumoUltrapassagemFP);
                cmd.Parameters.AddWithValue(prm_ConsumoUltrapassagem, c.ConsumoUltrapassagem);

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

        public int ExcluirConta(DateTime DataReferencia, int IdFabrica)
        {
            SqlParameter parametroSaida;
            String procNome = "sp_GerenciaConta";
            int status = 0;

            using (con = ConexaoBD.ObterConexao())
            {
                cmd = new SqlCommand(procNome, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FUNCAO", "4");
                cmd.Parameters.AddWithValue(prm_DataReferencia, DataReferencia);
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

        public ArrayList ObterContasPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            ArrayList contas = new ArrayList();
            String procNome = "sp_ObterContasPorPeriodo";
            Conta c;

            using (con = ConexaoBD.ObterConexao())
            {
                cmd = new SqlCommand(procNome, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(prm_DataInicio, dataInicio);
                cmd.Parameters.AddWithValue(prm_DataFim, dataFim);

                con.Open();
                using (SqlDataReader resultado = cmd.ExecuteReader())
                {
                    while (resultado.Read())
                    {
                        c = new Conta();
                        c.DataReferencia = resultado.GetDateTime(resultado.GetOrdinal(cp_DataReferencia));
                        c.IdFabrica = resultado.GetInt32(resultado.GetOrdinal(cp_IdFabrica));
                        c.ConsumoNP = resultado.GetDouble(resultado.GetOrdinal(cp_ConsumoNP));
                        c.ConsumoFP = resultado.GetDouble(resultado.GetOrdinal(cp_ConsumoFP));
                        c.DemandaTUSD = resultado.GetDouble(resultado.GetOrdinal(cp_DemandaTUSD));
                        c.ConsumoUltrapassagemNP = resultado.GetDouble(resultado.GetOrdinal(cp_ConsumoUltrapassagemNP));
                        c.ConsumoUltrapassagemFP = resultado.GetDouble(resultado.GetOrdinal(cp_ConsumoUltrapassagemFP));
                        c.ConsumoUltrapassagem = resultado.GetDouble(resultado.GetOrdinal(cp_ConsumoUltrapassagem));

                        contas.Add(c);
                    }
                }
            }

            return contas;

        }

    }
}