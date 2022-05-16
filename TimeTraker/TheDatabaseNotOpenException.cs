using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTraker
{
    internal class TheDatabaseNotOpenException : Exception
    {
        public TheDatabaseNotOpenException()
        {

        }

        public TheDatabaseNotOpenException(string message)
            : base(message)
        {
               
        }

        public TheDatabaseNotOpenException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
