using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioHR.EasyDatabases
{ 

    public delegate TContainer ContainerCreationCallback<TContainer, TObj>(TObj obj) where TContainer : IContainer<TObj>;

    public interface IContainer<TObj>
    {
        TObj Value { get; }
    }
}
