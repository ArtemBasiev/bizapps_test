using System;
using Ninject.Modules;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bizapps_test.DAL.Interfaces;
using bizapps_test.DAL.Repositories;

namespace bizapps_test.BLL.Infrastructure
{
    public class ServiceModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IBlogUserRepository>().To<BlogUserRepository>().InTransientScope();
            Bind<ICategoryRepository>().To<CategoryRepository>().InTransientScope();
            Bind<IPostRepository>().To<PostRepository>().InTransientScope();
        }


    }
}
