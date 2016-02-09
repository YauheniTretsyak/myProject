using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using KnowledgeAccounting.Dal.Interfaces;
using KnowledgeAccounting.Dal.Repositories;

namespace KnowledgeAccounting.Bll.Infrastructure
{
  public class ModuleForNinject : NinjectModule
  {
     private string connectionString;

     public ModuleForNinject(string connection)
     {
         connectionString = connection;
     }
     public override void Load()
     {
         Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);

     }
  }
}
