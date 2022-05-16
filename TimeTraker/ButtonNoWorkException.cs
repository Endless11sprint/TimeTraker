using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTraker
{
    internal class ButtonNoWorkException : Exception
    {
        public ButtonNoWorkException()
        {

        }

        public ButtonNoWorkException(string message)
            : base(message)
        {

        }

        public ButtonNoWorkException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
