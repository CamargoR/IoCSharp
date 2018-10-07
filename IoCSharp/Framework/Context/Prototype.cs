using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace IoCSharp.Framework.Context
{
    class Prototype<T> : Bean<T>
    {
        public Prototype(string name, Type type) : base(name, type) { }

        public override T Instance()
        {
            return (T)instance.GetType().GetMethod("MemberwiseClone",BindingFlags.NonPublic | BindingFlags.Instance).Invoke(instance, null);
        }
    }
}
