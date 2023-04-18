using System;
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
            Evento sherwood = new Evento("Sherwood", "14/07/2023", 2000);
            //Evento noname = new Evento("", "16/08/2023", 3000);
            //Evento pastDate = new Evento("Past Date", "12/07/2020", 5000);
            //Evento negativeSpots = new Evento("Negative spots", "06/09/2023", -2500);
        }
    }
}