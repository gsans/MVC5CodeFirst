using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.App.Infraestructure
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();        
    }
}
