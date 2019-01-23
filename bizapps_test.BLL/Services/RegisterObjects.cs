using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bizapps_test.DAL.Interfaces;
using bizapps_test.DAL.Repositories;

namespace bizapps_test.BLL.Services
{
    public static class RegisterObjects
    {

        public static void Register(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument("name = BizappsTestEntities");
        }



    }
}