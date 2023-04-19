using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventi
{
    public class ProgrammaEventi
    {
        private string Titolo { get; set; } //Titolo con SIA get che set
        private static List<Evento>? Eventi { get; set; }

        public ProgrammaEventi(string titolo)
        {
            Titolo = titolo;
            Eventi = new List<Evento>(); ;
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
            Console.WriteLine(miaLista);
            return miaLista;
        }

        public static void PrintList(List<Evento> eventList)
        {
            Console.WriteLine(eventList);
        }

        public void CountEvents()
        {
            Console.WriteLine(Eventi.Count);
        }

        public void EmptyEventList()
        {
            Eventi.Clear();
        }

        public string ShowProgram()
        {
            string ret = Titolo + ":\n";
            foreach (Evento evento in Eventi)
            {
                ret += evento.DataEvento + " - " + evento.Titolo + "\n";
            }
            Console.WriteLine(ret);
            return ret;
        }

    }
}