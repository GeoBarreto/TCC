using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Collections;
using System.Web.Mvc;

namespace TarifacaoEnergiaEletrica.Models
{
    public partial class ContaModel
    {
        public String DataInicialMes { get; set; }
        public String DataInicialAno { get; set; }
        public String DataFinalMes { get; set; }
        public String DataFinalAno { get; set; }
        public String DataReferenciaMes { get; set; }
        public String DataReferenciaAno { get; set; }
        public int IdFabrica { get; set; }
        public double ConsumoNP { get; set; }
        public double ConsumoFP { get; set; }
        public double DemandaTUSD { get; set; }
        public double ConsumoUltrapassagemNP { get; set; }
        public double ConsumoUltrapassagemFP { get; set; }
        public double ConsumoUltrapassagem { get; set; }
        public int IdTarifa { get; set; }
        public DateTime DataReferencia { get; set; }
        public double Total { get; set; }

        public Conta ConverterParaConta()
        {
            Conta c = new Conta();
            c.IdFabrica = IdFabrica;
            c.ConsumoNP = ConsumoNP;
            c.ConsumoFP = ConsumoFP;
            c.DemandaTUSD = DemandaTUSD;
            c.ConsumoUltrapassagemNP = ConsumoUltrapassagemNP;
            c.ConsumoUltrapassagemFP = ConsumoUltrapassagemFP;
            c.ConsumoUltrapassagem = ConsumoUltrapassagem;
            DataReferencia = DataModel.ContruirData("01", DataReferenciaMes, DataReferenciaAno);
            c.DataReferencia = DataReferencia;
            c.Total = Total;

            return c;
        }
    }

}
