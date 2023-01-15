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
        private string _formattazioneData = DateTime.Now.ToString("HH:mm - d/M/yyyy"); //formattazione della data dell'ultimo caricamento
        private string[] _valuteDisponibili = new string[] { "€", "£", "$" }; //valute default disponibili
        private double[] _tassi = new double[] { 1, 0.89, 1.08 }; //tassi default (rispetto all'euro)

        private double _importo; //importo
        private string _valutaVendi; //valuta dell'importo caricato
        private string _valutaCompra; //valuta dell'importo richiesto

        public MacchinaCambiaValute()
        {
            Id = "MacchinaCambiaValute-00";
            Ditta = "ditta_default";
            DataUltimoCaricamento = "00:00 - 01/01/2000";
        }
        public MacchinaCambiaValute(string id, string ditta)
        {
            Id = id;
            Ditta = ditta;
            DataUltimoCaricamento = "00:00 - 01/01/2000";
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

        public string FormattazioneData
        {
            set { _formattazioneData = value; }
            get { return _formattazioneData; }
        }

        public double Importo
        {
            set { _importo = value; }
            get { return _importo; }
        }

        public string ValutaVendi
        {
            set { _valutaVendi = value; }
            get { return _valutaVendi; }
        }
        public string[] ValuteDisponibili
        {
            set { _valuteDisponibili = value; }
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
                if (VerificaDisponibilitaValuta(valutaVendi) == true)
                {
                    ValutaVendi = valutaVendi;
                    Importo = importo;
                    DataUltimoCaricamento = FormattazioneData;
                }
                else
                {
                    throw new Exception("Valuta non disponibile, importo non caricato.");
                }
            }
            else
                throw new Exception("Importo non valido.");
        }

        public string Eroga()
        {
            double tmp = Importo;
            Importo = 0;
            ValutaCompra = null;
            ValutaVendi = null;
            return tmp + " " + ValutaCompra;
        }

        public bool VerificaDisponibilitaValuta(string valuta)//verifica se la valuta inserita è presente nell'array delle valute disponibili
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

        
        public double Converti(string valutaCompra) // converte tra le valute disponibili
        {
            ValutaCompra = valutaCompra;
            if (ValutaVendi == ValuteDisponibili[0]) // se vendi euro 
            {
                if (ValutaCompra == ValuteDisponibili[0]) // se ricompri euro
                {
                    return Importo;
                } 
                else if (ValutaCompra == ValuteDisponibili[1]) // se compri sterline
                {
                    Importo = Importo * Tassi[1];
                    return Approssima2decimali(Importo);
                }
                else if (ValutaCompra == ValuteDisponibili[2]) // se compri dollari
                {
                    Importo = Importo * Tassi[2];
                    return Approssima2decimali(Importo);
                }
                else // se valuta non disponibile
                    throw new Exception("Valuta richiesta non disponibile.");
            }
            else if (ValutaVendi == ValuteDisponibili[1]) // se vendi sterline 
            {
                if (ValutaCompra == ValuteDisponibili[1]) // se ricompri sterline
                {
                    return Importo;
                }
                else if (ValutaCompra == ValuteDisponibili[0]) // se compri euro
                {
                    Importo = Importo / Tassi[1]; // trasformo in euro
                    return Approssima2decimali(Importo);
                }
                else if (ValutaCompra == ValuteDisponibili[2]) // se compri dollari
                {
                    Importo = Importo / Tassi[1] * Tassi[2]; // trasformo in euro e sucessivamente in dollari
                    return Approssima2decimali(Importo);
                }
                else // se valuta non disponibile
                    throw new Exception("Valuta richiesta non disponibile.");
            }
            else if (ValutaVendi == ValuteDisponibili[2]) // se vendi dollari
            {

                if (ValutaCompra == ValuteDisponibili[2]) // se ricompri dollari
                {
                    return Importo;
                }
                else if (ValutaCompra == ValuteDisponibili[0]) // se compri euro
                {
                    Importo = Importo / Tassi[2]; // trasformo in euro
                    return Approssima2decimali(Importo);
                }
                else if (ValutaCompra == ValuteDisponibili[1]) // se compri sterline
                {
                    Importo = Importo / Tassi[2] * Tassi[1]; // trasformo in euro e sucessivamente in sterline
                    return Approssima2decimali(Importo);
                }
                else // se valuta non disponibile
                    throw new Exception("Valuta richiesta non disponibile.");
            }
            throw new Exception("Errore, riprovare utilizzando le valute disponibili.");
        }

        private double Approssima2decimali(double numero)
        {
            int tmp;
            numero = numero * 100;
            tmp = Convert.ToInt32(numero);
            numero = tmp;
            numero = numero / 100;
            return numero;
        }
        
    }
}
