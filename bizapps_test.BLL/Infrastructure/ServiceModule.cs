using Ninject.Modules;
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
            Bind<ICommentRepository>().To<CommentRepository>().InTransientScope();
        }


    }
}
