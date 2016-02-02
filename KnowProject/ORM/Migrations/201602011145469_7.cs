namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Knowledges",
                c => new
                    {
                        KnowledgeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.KnowledgeId);
            
            CreateTable(
                "dbo.UsersKnowledges",
                c => new
                    {
                        UsersKnowledgeId = c.Int(nullable: false, identity: true),
                        Degree = c.Int(nullable: false),
                        Description = c.String(),
                        UserId = c.Int(nullable: false),
                        KnowledgeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsersKnowledgeId)
                .ForeignKey("dbo.Knowledges", t => t.KnowledgeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.KnowledgeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        RoleId = c.Int(nullable: false),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersKnowledges", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UsersKnowledges", "KnowledgeId", "dbo.Knowledges");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.UsersKnowledges", new[] { "KnowledgeId" });
            DropIndex("dbo.UsersKnowledges", new[] { "UserId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.UsersKnowledges");
            DropTable("dbo.Knowledges");
        }
    }
}
