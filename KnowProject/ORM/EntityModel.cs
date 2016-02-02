using System;
using System.Data.Entity;
using System.Web.Helpers;

namespace ORM
{
    public partial class EntityModel : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<UsersKnowledge> UsersKnowledges { get; set; }

        static EntityModel()
        {
            Database.SetInitializer<EntityModel>(new DbInitializer());
        }
        public EntityModel()
            : base("DefaultConnection")
        {
        }

    }
    public class DbInitializer : DropCreateDatabaseIfModelChanges<EntityModel>
    {
        protected override void Seed(EntityModel db)
        {
            db.Roles.Add(new Role { Name = "Admin" });
            db.Roles.Add(new Role { Name = "User" });
            db.Users.Add(new User { Name = "Admin", Email="uvjen@tut.by", Password = Crypto.HashPassword("111111"), RoleId = 1 });
            db.Knowledges.Add(new Knowledge { Name = "C#" });
            db.UsersKnowledges.Add(new UsersKnowledge { Degree = 3, Description = "Not bad", UserId = 1, KnowledgeId = 1 });
            db.SaveChanges();
        }
    }
}
