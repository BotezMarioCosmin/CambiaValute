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
                m.Carica(1, "£");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine("Importo caricato: " + m.Importo + " " + m.ValutaVendi);

            try
            {
                Console.WriteLine("Data ultimo caricamento: " + m.DataUltimoCaricamento);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                m.Converti("$");
                Console.WriteLine("Importo convertito: " + m.Importo + " " + m.ValutaCompra);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
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
                Console.WriteLine("Erogazioni: " + m.ContaErogazioni);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            MacchinaCambiaValute m1 = m.Clone();
            Console.WriteLine(m.DataUltimoCaricamento);
            Console.WriteLine("Clone: " + m1.DataUltimoCaricamento);
            Console.WriteLine(m1.Equals(m));
            MacchinaCambiaValute m2 = new MacchinaCambiaValute("a", "lol");
            Console.WriteLine(m2.Equals(m));
            Console.WriteLine(m.ToString());


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
                m.Carica(20, "€");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Importo caricato: " + m.Importo + " " + m.ValutaVendi);

            try
            {
                Console.WriteLine("Data ultimo caricamento: " + m.DataUltimoCaricamento);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                m.Converti("$");
                Console.WriteLine("Importo convertito: " + m.Importo + " " + m.ValutaCompra);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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
                Console.WriteLine("Erogazioni: " + m.ContaErogazioni);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ///////
            Console.WriteLine("");

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
                m.Carica(55, "$");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Importo caricato: " + m.Importo + " " + m.ValutaVendi);

            try
            {
                Console.WriteLine("Data ultimo caricamento: " + m.DataUltimoCaricamento);
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
                Console.WriteLine("Importo convertito: " + m.Importo + " " + m.ValutaCompra);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                m.Converti("$");
                Console.WriteLine("Importo convertito: " + m.Importo + " " + m.ValutaCompra);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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
                Console.WriteLine("Erogazioni: " + m.ContaErogazioni);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
