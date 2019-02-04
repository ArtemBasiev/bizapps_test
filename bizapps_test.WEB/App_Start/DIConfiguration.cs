using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bizapps_test.BLL.Services;
using bizapps_test.BLL.Interfaces;
using Ninject;

namespace bizapps_test.WEB.App_Start
{
    public static class DIConfiguration
    {
        public static void SetupDI(IKernel kernel)
        {
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<IBlogUserService>().To<BlogUserService>();
            kernel.Bind<IPostService>().To<PostService>().InTransientScope();
        }
    }
}