using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizapps_test.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepositoty<Category> Categories { get; }
        void Save();
       
    }
}
