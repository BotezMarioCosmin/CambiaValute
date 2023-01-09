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
        private double[] _tassi = new double[] { 1, 1.12, 0.94};

        public double _importoCaricato;
        public double _tassoDollari = 0;
        public double _tassoSterline = 0;
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

        public double[] Tassi
        {
            set { _tassi = value; }
            get { return _tassi; }
        }

        public double TassoDollari
        {
            set 
            {
                if (value > 0)
                {
                    _tassoDollari = value;
                }
            }
            get { return _tassoDollari; }
        }

        public double TassoSterline
        {
            set
            {
                if (value > 0)
                {
                    _tassoSterline = value;
                }
            }
            get { return _tassoSterline; }
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

        public void valuteScambio(string vendi, string compra)//imposta le valute dello scambio
        {
            if (confrontaValute(vendi) == true && confrontaValute(compra) == true)
            {
                ValutaVendi = vendi;
                ValutaCompra = compra;
            }
            else
                throw new Exception("Valute non valide.");
        }

        public void tassoScambioEuroDollari(double tasso)//imposta il tasso dello scambio da Euro a Dollari
        {
            if (tasso > 0)
            {
                TassoDollari = tasso;
            }
            else
                throw new Exception("Tasso non valido");
        }

        public void tassoScambioEuroSterline(double tasso)//imposta il tasso dello scambio da Euro a Sterline
        {
            if (tasso > 0)
            {
                TassoSterline = tasso;
            }
            else
                throw new Exception("Tasso non valido");
        }

        public void Carica(double importo)
        {
            if (importo > 0)
            {
                ImportoCaricato = importo;
            }
            else
                throw new Exception("Importo non valido.");
        }
        
        public double ConvertiEuroDollari()
        {
            if (ImportoCaricato > 0 && TassoDollari > 0)
            {
                return ImportoCaricato * TassoDollari;
            }
            else
                throw new Exception("Caricare prima un importo!");
        }

        public double ConvertiEuroSterline()
        {
            if (ImportoCaricato > 0 && TassoSterline > 0)
            {
                return ImportoCaricato * TassoSterline;
            }
            else
                throw new Exception("Caricare prima un importo!");
        }

        public double Converti()
        { 
            for (int i = 0; i < ValuteDisponibili.Length; i++)
            {
                if (ValutaVendi == ValuteDisponibili[i])
                {
                    ImportoCaricato * Tassi[i];
                }
            }
        }
    }
}
