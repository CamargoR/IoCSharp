using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCSharp.Framework.Context
{
    abstract class Bean<T>
    {
        public string Name { get; private set; }

        public Type Type { get; private set; }

        protected T instance;

       
        public Bean(string name, Type type)
        {
            Name = name;
            Type = type;
            instance = (T)Activator.CreateInstance(type);
        }

        abstract public T Instance();
    }
}
