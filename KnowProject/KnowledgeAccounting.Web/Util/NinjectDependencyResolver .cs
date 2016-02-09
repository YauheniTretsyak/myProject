using KnowledgeAccounting.Bll.DTO;
using KnowledgeAccounting.Bll.Interfaces;
using KnowledgeAccounting.Bll.Providers;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeAccounting.Web.Util
{
  public class NinjectDependencyResolver : IDependencyResolver
  {
    private IKernel kernel;
    public NinjectDependencyResolver(IKernel kernelParam)
    {
      kernel = kernelParam;
      AddBindings();
    }
    public object GetService(Type serviceType)
    {
      return kernel.TryGet(serviceType);
    }
    public IEnumerable<object> GetServices(Type serviceType)
    {
      return kernel.GetAll(serviceType);
    }
    private void AddBindings()
    {
      kernel.Bind<IService<UserDTO>>().To<UserService>();
      kernel.Bind<IService<UserKnowledgeDTO>>().To<UserKnowledgeService>();
      kernel.Bind<IService<RoleDTO>>().To<RoleService>();
      kernel.Bind<IService<KnowledgeDTO>>().To<KnowledgeService>();
    }
  }
}