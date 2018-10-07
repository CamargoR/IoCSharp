using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAndAttributesPractice.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    class ManagedRepository : System.Attribute
    {
        public string name;
    }
}
