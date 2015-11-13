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
        //public IEnumerable<SelectListItem> listaMeses;
        //public IEnumerable<SelectListItem> listaAnos;
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

        /*public ContaModel()
        {

            listaMeses = ObterMeses();
            listaAnos = ObterAnos();

        }*/

        public static IEnumerable<SelectListItem> ObterMeses()
        {
            SelectList meses = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem {Text = "JAN", Value = "01"},
                    new SelectListItem {Text = "FEV", Value = "02"},
                    new SelectListItem {Text = "MAR", Value = "03"},
                    new SelectListItem {Text = "ABR", Value = "04"},
                    new SelectListItem {Text = "MAI", Value = "05"},
                    new SelectListItem {Text = "JUN", Value = "06"},
                    new SelectListItem {Text = "JUL", Value = "07"},
                    new SelectListItem {Text = "AGO", Value = "08"},
                    new SelectListItem {Text = "SET", Value = "09"},
                    new SelectListItem {Text = "OUT", Value = "10"},
                    new SelectListItem {Text = "NOV", Value = "11"},
                    new SelectListItem {Text = "DEZ", Value = "12"},
               }
               , "Value"
               , "Text"
            );

            return meses;
        }

        public static IEnumerable<SelectListItem> ObterAnos()
        {
            String ano;
            List<SelectListItem> lista = new List<SelectListItem>();
            SelectList anos;

            for (int i = 0; i < 50; i++) {
                ano = Convert.ToString(DateTime.Now.Year - i);
                lista.Add(new SelectListItem {Text = ano, Value = ano });
            }

            anos = new SelectList(lista, "Value", "Text");

            return anos;
        }

    }

}
