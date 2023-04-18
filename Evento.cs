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
        private string Titolo { get; set; }
        private DateOnly DataEvento { get; set; }
        private int MaxCap { get; }
        private int BookedSpots { get; }

        public Evento(string titolo, string dataEvento, int maxCap, int bookedSpots)
        {
            if (titolo != string.Empty)
            {
                Titolo = titolo;
                Console.WriteLine("Titolo: " + titolo);
            }
            else
                throw new ArgumentNullException(nameof(titolo));
            
            DateTime dataOraCorrente = DateTime.Now;
            DateOnly dataCorrente = new DateOnly(dataOraCorrente.Year, dataOraCorrente.Month, dataOraCorrente.Day);
            DateOnly data;
            DateOnly.TryParseExact(dataEvento, "d", out data);
            if (data > dataCorrente)
            {
                DataEvento = DateOnly.ParseExact(dataEvento, "d");
                Console.WriteLine("Data evento: " + dataEvento);
            }  
            else
            {
                throw new FormatException("Non puoi inserire una data passata.");
            }

            if (maxCap > 0)
            {
                MaxCap = maxCap;
                Console.WriteLine("Capienza massima: " + maxCap);
            }
            else
            {
                throw new ValoreNonValidoException("Il valore deve essere maggiore di zero.");
            }

            if (bookedSpots <= maxCap)
            {
                BookedSpots = bookedSpots;
                Console.WriteLine("Posti prenotati: " + bookedSpots);
            }
            
        }
    }
}