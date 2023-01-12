using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambiaValute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MacchinaCambiaValute m = new MacchinaCambiaValute();

            try
            {
                m.Carica(1, "€");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Importo caricato: " + m.Importo + " " + m.ValutaVendi);

            try
            {
                m.Converti("$");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Importo convertito: " + m.Importo + " " + m.ValutaCompra);

            Console.ReadKey();
        }
    }
}
