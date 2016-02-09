using KnowledgeAccounting.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace KnowledgeAccounting.Dal.EF
{
  public class Context : DbContext
  {
    
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<UsersKnowledge> UsersKnowledges { get; set; }
 
        static Context()
        {
            Database.SetInitializer<Context>(new DbInitializer());
        }
        public Context(string connectionString)
            : base(connectionString)
        {
        }
        public new void Dispose()
        {
          base.Dispose();
          
        }
  }
   public class DbInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context db)
        {
            db.Roles.Add(new Role { Name = "Admin" });
            db.Roles.Add(new Role { Name = "User" });
            db.Users.Add(new User { Name = "Admin", Password = Crypto.HashPassword("111111"),Email="uvjen@tut.by", RoleId = 1 });
            db.Knowledges.Add(new Knowledge { Name ="C#"});
            db.UsersKnowledges.Add(new UsersKnowledge { Degree = 3, Description = "Not bad", UserId = 1, KnowledgeId =1});
            db.SaveChanges();
        }
    }
}
