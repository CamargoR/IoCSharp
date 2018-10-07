using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCSharp.Framework.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    class Inject : System.Attribute
    {
        public string injectableName;
    }
}
