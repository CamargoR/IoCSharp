using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCSharp.Framework.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    class ManagedBean : System.Attribute
    {
        public string name;

        public bool singleton = true;
    }
}
