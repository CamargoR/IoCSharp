using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCSharp.Classes.Framework.Exception
{
    class BeanDefinitionException : System.Exception
    {
        public BeanDefinitionException() {}

        public BeanDefinitionException(string message) : base(message) { }

        public BeanDefinitionException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
