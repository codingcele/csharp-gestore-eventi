using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventi
{
    public class Evento
    {
        public string Titolo { get; set; } //Titolo con SIA get che set
        public DateOnly DataEvento { get; set; } //DataEvento con SIA get che set
        private int MaxCap { get; } //MaxCap con SOLO GET
        private int BookedSpots { get; set; } //BookedSpots con SIA get che set

        public Evento(string titolo, string dataEvento, int maxCap)
        {
            if (titolo != string.Empty) //controllo che il titolo non sia vuoto
            {
                Titolo = titolo;
            }
            else
                throw new ArgumentNullException(nameof(titolo)); //throw exception se il titolo è vuoto
            
            DateTime dataOraCorrente = DateTime.Now;
            DateOnly dataCorrente = new DateOnly(dataOraCorrente.Year, dataOraCorrente.Month, dataOraCorrente.Day);
            DateOnly.TryParseExact(dataEvento, "d", out var data);
            if (data > dataCorrente) //controllo che la data dell'evento non sia passata
            {
                DataEvento = DateOnly.ParseExact(dataEvento, "d");
            }  
            else
            {
                throw new Exception("Non puoi inserire una data passata."); //throw exception customizzata se la data è passata
            }

            if (maxCap > 0) //controllo che la capacità massima dell'evento sia positiva
            {
                MaxCap = maxCap;
            }
            else
            {
                throw new Exception("Il valore deve essere maggiore di zero."); // throw exception customizzata se il valore è negativo
            }

            BookedSpots = 0; // Imposta il valore di default di BookedSpots a 0
        }

        public void PrenotaPosti(int nrBookedSpots) 
        {
            DateTime dataOraCorrente = DateTime.Now;
            DateOnly dataCorrente = new DateOnly(dataOraCorrente.Year, dataOraCorrente.Month, dataOraCorrente.Day);
            if (DataEvento < dataCorrente) //setto la condizione per la quale la data dell'evento sia passata
            {
                throw new Exception("La data è passata."); //throw exception customizzata se la data è passata

            }
            else if (MaxCap == 0) // setto la condizione che i posti dell'evento non esistano
            {
                throw new Exception("L'evento ha 0 posti."); //throw exception customizzata se i posti dell'evento sono 0
            }
            else if (MaxCap - BookedSpots < nrBookedSpots) // setto la condizione che i posti rimasti siano minori di quelli che l'utente vuole prenotare 
            {
                throw new Exception("I posti rimasti sono meno di quelli che vuoi prenotare."); //throw exception customizzata se i posti rimasti sono meno di quelli che l'utente vuole prenotare
            }
            else if (MaxCap - BookedSpots == 0) //setto la condizione che i posti siano esauriti
            {
                throw new Exception("I posti sono esauriti."); //throw exception customizzata se i posti sono esauriti
            }
            else
            {
                BookedSpots += nrBookedSpots;
                Console.WriteLine();
                Console.WriteLine("Numero di posti prenotati = " + BookedSpots);
                Console.WriteLine("Numero di posti disponibili = " + (MaxCap - BookedSpots));
            } 
        }

        public void DisdiciPosti()
        {
            Console.WriteLine();
            Console.Write("Vuoi disdire dei posti (si/no)? ");
            string ans = Console.ReadLine();
            int nrUndoSpots = 0;

            DateTime dataOraCorrente = DateTime.Now;
            DateOnly dataCorrente = new DateOnly(dataOraCorrente.Year, dataOraCorrente.Month, dataOraCorrente.Day);
            if (DataEvento < dataCorrente) //setto la condizione per la quale la data dell'evento sia passata
            {
                throw new Exception("La data è passata."); //throw exception customizzata se la data è passata

            }
            else if (BookedSpots < nrUndoSpots) // setto la condizione per triggerare l'exception per i posti rimasti insufficienti
            {
                throw new Exception("Non puoi disdire più posti di quelli rimasti."); //throw exception customizzata se i posti dell'evento sono 0
            }
            else
            {
                if (ans == "si")
                {
                    Console.Write("Indica il numero di posti da disdire: ");
                    int nrSpots = int.Parse(Console.ReadLine());
                    nrUndoSpots += nrSpots;
                    BookedSpots -= nrUndoSpots;
                    Console.WriteLine();
                    Console.WriteLine("Numero di posti prenotati = " + BookedSpots);
                    Console.WriteLine("Numero di posti disponibili = " + (MaxCap - BookedSpots));
                    DisdiciPosti();
                }
                else
                {
                    Console.WriteLine("Ok va bene!");
                    Console.WriteLine();
                    Console.WriteLine("Numero di posti prenotati = " + BookedSpots);
                    Console.WriteLine("Numero di posti disponibili = " + (MaxCap - BookedSpots));
                }
            }
        }

        public override string ToString()
        {
            Console.WriteLine(DataEvento + " - " + Titolo);
            return DataEvento + Titolo;
        }

    }
}