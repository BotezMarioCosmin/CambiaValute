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
        private string[] _valuteDisponibili = new string[] { "€","£","$"}; //valute default disponibili
        private double[] _tassi = new double[] { 1, 1.12, 0.94}; //tassi default (rispetto all'euro)

        private double _importo; //importo
        private string _valuta; //valuta dell'importo
        private string _valutaCompra;

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

        public MacchinaCambiaValute(string id, string ditta, string dataUltimoCaricamento, string[] valuteDisponibili)
        {
            Id = id;
            Ditta = ditta;
            DataUltimoCaricamento = dataUltimoCaricamento;
            ValuteDisponibili = valuteDisponibili;
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

        public double Importo
        {
            set { _importo = value; }
            get { return _importo; }
        }

        public string ValutaVendi
        {
            set { _valuta = value; }
            get { return _valuta; }
        }
        public string[] ValuteDisponibili
        {
            set { _valuteDisponibili = value;}
            get { return _valuteDisponibili; }
        }

        public double[] Tassi
        {
            set { _tassi = value; }
            get { return _tassi; }
        }

        public string ValutaCompra
        {
            set { _valutaCompra = value; }
            get { return _valutaCompra; }
        }

        public void Carica(double importo, string valutaVendi)//carica l'importo con la sua valuta
        {
            if (importo > 0)
            {
                if (verificaDisponibilitaValuta(valutaVendi) == true)
                {
                    ValutaVendi = valutaVendi;
                    Importo = importo;
                }
                else
                {
                    throw new Exception("Valuta non disponibile, importo non caricato.");
                }
            }
            else
                throw new Exception("Importo non valido.");

        }

        public bool verificaDisponibilitaValuta(string valuta)//verifica se la valuta inserita è presente nell'array delle valute disponibili
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

        
        public double Converti(string valutaCompra)
        {
            ValutaCompra = valutaCompra;
            if (ValutaVendi == ValuteDisponibili[0])
            {
                if (ValutaCompra == ValuteDisponibili[1])
                {
                    Importo = Importo * Tassi[1];
                    return Importo;
                }
                else if (ValutaCompra == ValuteDisponibili[2])
                {
                    Importo = Importo * Tassi[2];
                    return Importo;
                }
                else
                    throw new Exception("Valuta richiesta non disponibile.");
            }
            return 0;
        }
        

        //// aggiuntive al converti
        /*
        public double ConvertiEuroDollari()
        {
            if (ImportoCaricato > 0 && TassoDollari > 0)
            {
                return ImportoCaricato * TassoDollari;
            }
        }

        public double ConvertiEuroSterline()
        {
            if (ImportoCaricato > 0 && TassoSterline > 0)
            {
                return ImportoCaricato * TassoSterline;
            }
        }*/
    }
}
