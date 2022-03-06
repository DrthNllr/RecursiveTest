using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecursiveTest.Entities;

namespace RecursiveTest
{
    public class PlazaPresenter
    {
        public Plaza Plaza { get; set; }
        private string formatoFechaHora = "yyyy-MM-ddTHH:mm:ss.fffffffK";

        public PlazaPresenter(Plaza? plaza)
        {
            Plaza = plaza != null ? plaza : new Plaza() { Id = Guid.Empty };
        }

        public void PrintPlaza(string prefijo, bool imprimeFechaHora = true)
        {
            Console.WriteLine((imprimeFechaHora ? DateTime.Now.ToString(formatoFechaHora) + " - " : "") + $"{prefijo.Trim()} {this}.");
        }

        public override string ToString()
        {
            return (Plaza != null ? $"{Plaza.CodPago:00}{Plaza.Unidad:00}{Plaza.SubUnidad:00}{Plaza.CatPuesto}{Plaza.Horas:00.0}{Plaza.ConsPlaza:000000}" : "-Sin Clave Presupuestal-")
                + (Plaza != null && Plaza.PlazaOrigenNavigation != null ? $" (Con origen {new PlazaPresenter(Plaza.PlazaOrigenNavigation)})" : "");
        }
    }
}