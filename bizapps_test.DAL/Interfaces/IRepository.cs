using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizapps_test.DAL.Interfaces
{
    public interface IRepositoty<T> where T: class

    {
        IEnumerable<T> GetAll();
  
        void Create(T item);
    }
}
