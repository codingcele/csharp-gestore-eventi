using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventi
{
    public class ProgrammaEventi
    {
        public string Titolo { get; set; } //Titolo con SIA get che set
        public List<Evento> Eventi { get; set; }

        public ProgrammaEventi(string titolo)
        {
            Titolo = titolo;
            Eventi = new List<Evento>();
        }

        public void AddEvent(Evento evento)
        {
            Eventi.Add(evento);
        }
    
        public List<Evento> ReturnEventList(DateOnly dataEvento)
        {
            List<Evento> miaLista = new List<Evento>();
            foreach (Evento evento in Eventi)
            {
                if (evento.DataEvento == dataEvento)
                    miaLista.Add(evento);
            }
            return miaLista;
        }

        public static string PrintList(List<Evento> eventList)
        {
            string ret = "";
            foreach (Evento evento in eventList)
            {
                ret += evento.ToString() + "\n";
            }
            Console.WriteLine(ret);
            return ret;
        }

        public void CountEvents()
        {
            Console.WriteLine("Il numero di eventi del programma è: " + Eventi.Count);
        }

        public void EmptyEventList()
        {
            Eventi.Clear();
        }

        public string ShowProgram()
        {
            string ret = Titolo + "\n";
            foreach (Evento evento in Eventi)
            {
                ret += evento.ToString() + "\n";
            }
            Console.WriteLine("Ecco il tuo programma eventi:");
            Console.WriteLine(ret);
            return ret;
        }

    }
}