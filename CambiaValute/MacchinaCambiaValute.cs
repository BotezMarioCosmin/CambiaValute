using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambiaValute
{
    public class MacchinaCambiaValute
    {
        //attributi invariabili dopo dichiarazione oggetto
        private string _id; //primary key
        private string _ditta; //ditta produttrice
        private string _formattazioneData = DateTime.Now.ToString("HH:mm - d/M/yyyy"); //formattazione della data dell'ultimo caricamento
        private string[] _valuteDisponibili = new string[] { "€", "£", "$" }; //valute default disponibili

        //attributi variabili dopo dichiarazione oggetto
        private double[] _tassi = new double[] { 1, 0.89, 1.08 }; //tassi default (rispetto all'euro)
        private string _dataUltimoCaricamento; //data dell'ultimo caricamento di denaro
        private int _contaErogazioni;
        private double _importo; //importo
        private string _valutaVendi; //valuta dell'importo caricato
        private string _valutaCompra; //valuta dell'importo richiesto

        public MacchinaCambiaValute()
        {
            Id = "MacchinaCambiaValute-00";
            Ditta = "ditta_default";
            DataUltimoCaricamento = "00:00 - 01/01/2000";
            ContaErogazioni = 0;
        }
        public MacchinaCambiaValute(string id, string ditta)
        {
            Id = id;
            Ditta = ditta;
            DataUltimoCaricamento = "00:00 - 01/01/2000";
            ContaErogazioni = 0;
        }

        public MacchinaCambiaValute(string id, string ditta, string dataUltimoCaricamento)
        {
            Id = id;
            Ditta = ditta;
            DataUltimoCaricamento = dataUltimoCaricamento;
            ContaErogazioni = 0;
        }

        public MacchinaCambiaValute(string id, string ditta, string dataUltimoCaricamento, double[] tassi)
        {
            Id = id;
            Ditta = ditta;
            DataUltimoCaricamento = dataUltimoCaricamento;
            Tassi = tassi;
            ContaErogazioni = 0;
        }

        public MacchinaCambiaValute(string id, string ditta, string dataUltimoCaricamento, double[] tassi, int contaErogazioni)
        {
            Id = id;
            Ditta = ditta;
            DataUltimoCaricamento = dataUltimoCaricamento;
            Tassi = tassi;
            ContaErogazioni = contaErogazioni;
        }

        public string Id
        {
            private set 
            {
                if (value != null)
                {
                    _id = value;
                }
                else
                    throw new Exception("Id non valido");
            }
            get { return _id; }
        }

        public string Ditta
        {
            private set
            {
                if (value != null)
                {
                    _ditta = value;
                }
                else
                    throw new Exception("Ditta non valida");
            }
            get { return _ditta; }
        }

        public string DataUltimoCaricamento
        {
            set
            {
                if (value != null)
                {
                    _dataUltimoCaricamento = value;
                }
                else
                    throw new Exception("Data non valida");
            }
            get { return _dataUltimoCaricamento; }
        }

        public string FormattazioneData
        {
            private set 
            {
                if (value != null)
                {
                    _formattazioneData = value;
                }
                else
                    throw new Exception("Formattazione data non valida");
            }
            get { return _formattazioneData; }
        }

        public double Importo
        {
            private set { _importo = value; }
            get { return ApprossimaACentesimi(_importo); }
        }

        public string ValutaVendi
        {
            private set { _valutaVendi = value; }
            get { return _valutaVendi; }
        }
        public string ValutaCompra
        {
            private set { _valutaCompra = value; }
            get { return _valutaCompra; }
        }
        public string[] ValuteDisponibili
        {
            private set { _valuteDisponibili = value; }
            get { return _valuteDisponibili; }
        }

        public double[] Tassi
        {
            set { _tassi = value; }
            get { return _tassi; }
        }

        public int ContaErogazioni
        {
            private set { _contaErogazioni = value; }
            get { return _contaErogazioni; }
        }

        public void Carica(double importo, string valutaVendi) //carica l'importo con la sua valuta
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
                throw new Exception("Importo non valido, deve essere maggiore di 0.");
        }

        public string Eroga() //resetta tutti gli attributi per le conversioni e aumenta il conta erogazioni
        {
            double tmp = Importo;
            Importo = 0;
            string tmp1 = ValutaCompra;
            ValutaCompra = null;
            ValutaVendi = null;
            ContaErogazioni++;
            return tmp + " " + tmp1;
        }

        public bool VerificaDisponibilitaValuta(string valuta) //verifica se la valuta inserita è presente nell'array delle valute disponibili
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
                    ValutaVendi = ValutaCompra; // serve se faccio nuovamente la conversione prima di erogare
                    return ApprossimaACentesimi(Importo);
                } 
                else if (ValutaCompra == ValuteDisponibili[1]) // se compri sterline
                {
                    ValutaVendi = ValutaCompra; // serve se faccio nuovamente la conversione prima di erogare
                    Importo = Importo * Tassi[1];
                    return ApprossimaACentesimi(Importo);
                }
                else if (ValutaCompra == ValuteDisponibili[2]) // se compri dollari
                {
                    ValutaVendi = ValutaCompra; // serve se faccio nuovamente la conversione prima di erogare
                    Importo = Importo * Tassi[2];
                    return ApprossimaACentesimi(Importo);
                }
                else // se valuta non disponibile
                    throw new Exception("Valuta richiesta non disponibile.");
            }
            else if (ValutaVendi == ValuteDisponibili[1]) // se vendi sterline 
            {
                if (ValutaCompra == ValuteDisponibili[1]) // se ricompri sterline
                {
                    ValutaVendi = ValutaCompra; // serve se faccio nuovamente la conversione prima di erogare
                    return ApprossimaACentesimi(Importo);
                }
                else if (ValutaCompra == ValuteDisponibili[0]) // se compri euro
                {
                    ValutaVendi = ValutaCompra; // serve se faccio nuovamente la conversione prima di erogare
                    Importo = Importo / Tassi[1]; // trasformo in euro
                    return ApprossimaACentesimi(Importo);
                }
                else if (ValutaCompra == ValuteDisponibili[2]) // se compri dollari
                {
                    ValutaVendi = ValutaCompra; // serve se faccio nuovamente la conversione prima di erogare
                    Importo = Importo / Tassi[1] * Tassi[2]; // trasformo in euro e sucessivamente in dollari
                    return ApprossimaACentesimi(Importo);
                }
                else // se valuta non disponibile
                    throw new Exception("Valuta richiesta non disponibile.");
            }
            else if (ValutaVendi == ValuteDisponibili[2]) // se vendi dollari
            {

                if (ValutaCompra == ValuteDisponibili[2]) // se ricompri dollari
                {
                    ValutaVendi = ValutaCompra; // serve se faccio nuovamente la conversione prima di erogare
                    return ApprossimaACentesimi(Importo);
                }
                else if (ValutaCompra == ValuteDisponibili[0]) // se compri euro
                {
                    ValutaVendi = ValutaCompra; // serve se faccio nuovamente la conversione prima di erogare
                    Importo = Importo / Tassi[2]; // trasformo in euro
                    return ApprossimaACentesimi(Importo);
                }
                else if (ValutaCompra == ValuteDisponibili[1]) // se compri sterline
                {
                    ValutaVendi = ValutaCompra; // serve se faccio nuovamente la conversione prima di erogare
                    Importo = Importo / Tassi[2] * Tassi[1]; // trasformo in euro e sucessivamente in sterline
                    return ApprossimaACentesimi(Importo);
                }
                else // se valuta non disponibile
                    throw new Exception("Valuta richiesta non disponibile.");
            }
            throw new Exception("Errore, riprovare utilizzando le valute disponibili.");
        }

        private double ApprossimaACentesimi(double numero)
        {
            int tmp;
            numero = numero * 100;
            tmp = Convert.ToInt32(numero);
            numero = tmp;
            numero = numero / 100;
            return numero;
        }

        public MacchinaCambiaValute Clone()
        {
            return new MacchinaCambiaValute(this.Id, this.Ditta, this.DataUltimoCaricamento, this.Tassi, this.ContaErogazioni);
        }

        public bool Equals(MacchinaCambiaValute m) // confronta due macchine cambia valute
        {
            if (m == null) return false;

            if (this == m) return true;

            return (this.Id == m.Id);
        }

        public override string ToString() // mette a stringa le informazioni della macchina cambia valute
        { 
            return "\n" + "Informazioni Macchina Cambia Valute: " + "\n" + "   Id: " + Id + "\n" + "   Ditta: " + Ditta + "\n" + 
                "   Data ultimo caricamento: " + DataUltimoCaricamento + "\n" + "   Valute disponibili: " + ValuteDisponibili[0]
                + " " + ValuteDisponibili[1] + " " + ValuteDisponibili[2] + "\n" + "   Tassi (rispetto euro): " + Tassi[0]
                + " " + Tassi[1] + " " + Tassi[2] + "\n" + "   Numero Erogazioni: " + ContaErogazioni + "\n";
        }
    }
}
