using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCSharp.Framework.Context
{
    class Singleton<T> : Bean<T> 
    {
        public Singleton(string name, System.Type type) : base(name, type){ }

        public override T Instance()
        {
            return instance;
        }
    }
}
