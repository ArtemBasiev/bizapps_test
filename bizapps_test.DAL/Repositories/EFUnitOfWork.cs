using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bizapps_test.DAL.Interfaces;
using System.Data.Entity;

namespace bizapps_test.DAL.Repositories
{
    public class EFUnitOfWork: IUnitOfWork
    {
        private BizappsTestEntities db;
        private CategoryRepository categoryRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new BizappsTestEntities(connectionString);
        }
    

     public IRepositoty<Category> Categories
        {
           get
            {
                if (categoryRepository == null)
                categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = true;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
