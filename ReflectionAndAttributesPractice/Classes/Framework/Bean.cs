using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAndAttributesPractice.Classes.Framework
{
    abstract class Bean<T>
    {
        public string Name { get; private set; }

        public Type Type { get; private set; }

        public IList<Bean<T>> DependsOn { get; private set; }

        protected T instance;

       
        public Bean(string name, Type type)
        {
            Name = name;
            Type = type;
            instance = (T)Activator.CreateInstance(typeof(T));
        }

        abstract public T Instance();

        public void AddDependence(Bean<T> bean)
        {
            if (DependsOn == null)
            { 
                DependsOn = new List<Bean<T>>();
            }

            DependsOn.Add(bean);
        }
    }
}
