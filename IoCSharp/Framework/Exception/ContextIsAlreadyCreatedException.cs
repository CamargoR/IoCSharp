using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCSharp.Framework.Exception
{
    class ContextIsAlreadyCreatedException : System.Exception
    {
        public ContextIsAlreadyCreatedException() { }

        public ContextIsAlreadyCreatedException(string message) : base(message) { }
    }
}
