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
                m.valuteScambio("€", "$"); ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                m.tassoScambioEuroDollari(0.94);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                m.tassoScambioEuroSterline(1.14);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                m.Carica(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine(m.ConvertiEuroSterline());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadKey();
        }
    }
}
