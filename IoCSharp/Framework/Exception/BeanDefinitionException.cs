using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCSharp.Framework.Exception
{
    public class BeanDefinitionException : System.Exception
    {
        public BeanDefinitionException() {}

        public BeanDefinitionException(string message) : base(message) { }

        public BeanDefinitionException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
