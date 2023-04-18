using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{

    public class DataPassata : Exception
    {
        public DataPassata(string message) : base(message)
        {
        }
    }

    public class ValoreNonValidoException : Exception
    {
        public ValoreNonValidoException(string message) : base(message)
        {
        }
    }

}