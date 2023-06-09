﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Evento sherwood = new Evento("Sherwood", "14/07/2023", 2000);
            //Evento noName = new Evento("", "16/08/2023", 3000);
            //Evento pastDate = new Evento("Past Date", "12/07/2020", 5000);
            //Evento negativeSpots = new Evento("Negative spots", "06/09/2023", -2500);
            //sherwood.PrenotaPosti(3);
            //sherwood.PrenotaPosti(4);
            //sherwood.DisdiciPosti(6);
            //sherwood.DisdiciPosti(7);
            //sherwood.DisdiciPosti(8);
            //sherwood.ToString();

            //Console.Write("Inserisci il nome dell'evento: ");
            //string titolo = Console.ReadLine();

            //Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
            //string data = Console.ReadLine();

            //Console.Write("Inserisci il numero di posti totali: ");
            //int nrTotPosti = int.Parse(Console.ReadLine());

            //Evento NewEvent = new Evento(titolo, data, nrTotPosti);

            //Console.Write("Quanti posti desideri prenotare? ");
            //int nrPostiPrenotazione = int.Parse(Console.ReadLine());

            //NewEvent.PrenotaPosti(nrPostiPrenotazione);

            //NewEvent.DisdiciPosti();

            Console.Write("Inserisci il nome del tuo programma eventi: ");
            string titoloProgramma = Console.ReadLine();

            Console.Write("Inserisci il numero di eventi da inserire: ");
            int nrEventiProgramma = int.Parse(Console.ReadLine());

            ProgrammaEventi newProgramma = new ProgrammaEventi(titoloProgramma);

            while (newProgramma.Eventi.Count != nrEventiProgramma)
            {
                Console.Write("Inserisci il nome del " + (newProgramma.Eventi.Count + 1) + "° evento: ");
                string titolo = Console.ReadLine();

                Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
                string data = Console.ReadLine();

                Console.Write("Inserisci il numero di posti totali: ");
                int nrTotPosti = int.Parse(Console.ReadLine());

                Evento NewEvent = new Evento(titolo, data, nrTotPosti);

                newProgramma.AddEvent(NewEvent);

            }
            newProgramma.CountEvents();
            newProgramma.ShowProgram();

            Console.Write("Inserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");
            string dataQuery = Console.ReadLine();
            DateOnly.TryParseExact(dataQuery, "d", out var dataFormat);
            List<Evento> listaData = newProgramma.ReturnEventList(dataFormat);

            ProgrammaEventi.PrintList(listaData);

            newProgramma.EmptyEventList();

        }
    }
}