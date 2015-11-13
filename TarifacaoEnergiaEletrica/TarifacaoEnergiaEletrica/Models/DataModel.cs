using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TarifacaoEnergiaEletrica.Models
{
    class DataModel
    {
        public static DateTime ContruirData(String dia, String mes, String ano)
        {
            DateTime data = new DateTime();
            data = DateTime.ParseExact(ano + "-" + mes + "-"  + dia, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            return data;
        }

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

            for (int i = 0; i < 50; i++)
            {
                ano = Convert.ToString(DateTime.Now.Year - i);
                lista.Add(new SelectListItem { Text = ano, Value = ano });
            }

            anos = new SelectList(lista, "Value", "Text");

            return anos;
        }
    }
}
