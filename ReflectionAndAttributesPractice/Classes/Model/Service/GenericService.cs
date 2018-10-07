using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionAndAttributesPractice.Attributes;

namespace ReflectionAndAttributesPractice.Classes.Model.Service
{
    [ManagedBean(name = "genericService")]
    class Service
    {
        //[Inject(injectableName = "genericRepository")]
        //public GenericRepository repository;

    }
}
