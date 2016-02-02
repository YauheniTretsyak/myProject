using BLL.Interface.Services;
using BLL.Services;
using DAL.Concrete;
using Ninject.Modules;
using ORM;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyResolver
{
    public class RevolverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<EntityModel>().InSingletonScope();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IRoleRepository>().To<RoleRepository>();
            Bind<IKnowledgeRepository>().To<KnowledgeRepository>();
            Bind<IUsersKnowledgeRepository>().To<UsersKnowledgeRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUserService>().To<UserService>();
            Bind<IRoleService>().To<RoleService>();
            Bind<IKnowledgeService>().To<KnowledgeService>();
            Bind<IUserKnowledgeService>().To<UserKnowledgeService>();
        }
    }
}
