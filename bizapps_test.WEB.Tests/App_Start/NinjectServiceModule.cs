using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Ninject;
using bizapps_test.BLL.Services;
using bizapps_test.BLL.Interfaces;

namespace bizapps_test.WEB.Tests.App_Start
{
    public class NinjectServiceModule: NinjectModule
    {

        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryService>().InTransientScope();
            Bind<IBlogUserService>().To<BlogUserService>().InTransientScope();
            Bind<IPostService>().To<PostService>().InTransientScope();
        }
    }
}