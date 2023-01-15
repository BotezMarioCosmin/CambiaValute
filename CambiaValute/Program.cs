using System;
using System.Collections.Generic;
using System.Configuration;
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
                Console.WriteLine("Valute disponibili: " + m.ValuteDisponibili[0] + m.ValuteDisponibili[1] + m.ValuteDisponibili[2]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                m.Carica(1, "$");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("Data ultimo caricamento: " + m.DataUltimoCaricamento);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Importo caricato: " + m.Importo + " " + m.ValutaVendi);

            try
            {
                Console.WriteLine("Importo erogato: " + m.Eroga());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                m.Converti("£");
                Console.WriteLine("Importo convertito: " + m.Importo + " " + m.ValutaCompra);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                m.Converti("€");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Importo convertito: " + m.Importo + " " + m.ValutaCompra);
            }


            Console.ReadKey();
        }
    }
}
