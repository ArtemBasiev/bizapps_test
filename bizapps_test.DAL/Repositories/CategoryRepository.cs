using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bizapps_test.DAL.Interfaces;
using System.Data.Entity;


namespace bizapps_test.DAL.Repositories
{
    class CategoryRepository: IRepositoty<Category>
    {
        private BizappsTestEntities db;

        public CategoryRepository(BizappsTestEntities context)
        {
            this.db = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Category.ToList();
        }


        public void Create(Category category)
        {
            db.Category.Add(category);
        }
    }
}
