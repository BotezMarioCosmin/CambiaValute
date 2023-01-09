using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambiaValute
{
    public class MacchinaCambiaValute
    {
        private string _id; //primary key
        private string _ditta; //ditta produttrice
        private string _dataUltimoCaricamento; //data dell'ultimo aricamento di denaro
        private string[] _valuteDisponibili = new string[] { "€","£","$"};

        public double _importoCaricato;
        public double _tasso = 0;
        public string _valutaVendi;
        public string _valutaCompra;

        public MacchinaCambiaValute()
        {
            Id = "MacchinaCambiaValute-00";
            Ditta = "ditta_default";
            DataUltimoCaricamento = "01/01/2000";
        }

        public MacchinaCambiaValute(string id, string ditta, string dataUltimoCaricamento)
        {
            Id = id;
            Ditta = ditta;
            DataUltimoCaricamento = dataUltimoCaricamento;
        }

        public string Id
        {
            set { _id = value; }
            get { return _id; }        
        }

        public string Ditta
        { 
            set { _ditta = value; }
            get { return _ditta; }
        }

        public string DataUltimoCaricamento
        {
            set { _dataUltimoCaricamento = value; }
            get { return _dataUltimoCaricamento; }
        }

        public double ImportoCaricato
        {
            set { _importoCaricato = value; }
            get { return _importoCaricato; }
        }

        public string[] ValuteDisponibili
        {
            set { _valuteDisponibili = value;}
            get { return _valuteDisponibili; }
        }

        public double Tasso
        {
            set 
            {
                if (value > 0)
                {
                    _tasso = value;
                }
            }
            get { return _tasso; }
        }

        public string ValutaVendi
        {
            set 
            { 
                _valutaVendi = value; 
            }
            get { return _valutaVendi; }
        }

        public string ValutaCompra
        {
            set { _valutaCompra = value; }
            get { return _valutaCompra; }
        }

        public bool confrontaValute(string valuta)//verifica se la valuta inserita è presente nell'array delle valute disponibili
        {
            for (int i = 0; i < ValuteDisponibili.Length; i++)
            {
                if (valuta == ValuteDisponibili[i])
                {
                    return true;
                }
            }
            return false;
        }

        public void tassiScambio(string vendi, string compra)//imposta le valute dello scambio
        {
            if (confrontaValute(vendi) == true && confrontaValute(compra) == true)
            {
                ValutaVendi = vendi;
                ValutaCompra = compra;
            }
            else
                throw new Exception("Valute non valide.");
        }
        /*
        public void tasso()
        {
            if (Tasso > 0)
            { 
            
            }
        }
        */
        public void Carica(double importo)
        {
            if (importo > 0)
            {
                ImportoCaricato = importo;
            }
            else
                throw new Exception("Importo non valido.");
        }
        /*
        public double Converti(double importoRestituito)
        {
            if (ImportoCaricato > 0)
            {
                
            }
            else
                throw new Exception("Caricare prima un importo!");
        }*/
    }
}
