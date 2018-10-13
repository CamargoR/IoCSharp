using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCSharp.Framework.Exception
{
    class PrototypeToSingletonInjectionException : System.Exception
    {
        public PrototypeToSingletonInjectionException() { }

        public PrototypeToSingletonInjectionException(string message) : base(message) { }
    }
}
