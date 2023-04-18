using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace Eventi
{
    public class Evento
    {
        private string Titolo { get; set; } //Titolo con SIA get che set
        private DateOnly DataEvento { get; set; } //DataEvento con SIA get che set
        private int MaxCap { get; } //MaxCap con SOLO GET
        private int BookedSpots { get; } //BookedSpots con SOLO GET

        public Evento(string titolo, string dataEvento, int maxCap)
        {
            if (titolo != string.Empty) //controllo che il titolo non sia vuoto
            {
                Titolo = titolo;
                Console.WriteLine("Titolo: " + titolo);
            }
            else
                throw new ArgumentNullException(nameof(titolo)); //throw exception se il titolo è vuoto
            
            DateTime dataOraCorrente = DateTime.Now;
            DateOnly dataCorrente = new DateOnly(dataOraCorrente.Year, dataOraCorrente.Month, dataOraCorrente.Day);
            DateOnly data;
            DateOnly.TryParseExact(dataEvento, "d", out data);
            if (data > dataCorrente) //controllo che la data dell'evento non sia passata
            {
                DataEvento = DateOnly.ParseExact(dataEvento, "d");
                Console.WriteLine("Data evento: " + dataEvento);
            }  
            else
            {
                throw new DataPassata("Non puoi inserire una data passata."); //throw exception customizzata se la data è passata
            }

            if (maxCap > 0) //controllo che la capacità massima dell'evento sia positiva
            {
                MaxCap = maxCap;
                Console.WriteLine("Capienza massima: " + maxCap);
            }
            else
            {
                throw new ValoreNonValidoException("Il valore deve essere maggiore di zero."); // throw exception customizzata se il valore è negativo
            }

            BookedSpots = 0; // Imposta il valore di default di BookedSpots a 0
            Console.WriteLine("Posti prenotati: " + BookedSpots);
            
        }
    }
}