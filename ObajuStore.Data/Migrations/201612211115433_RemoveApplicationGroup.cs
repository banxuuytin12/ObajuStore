namespace ObajuStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveApplicationGroup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationRoleGroups", "GroupId", "dbo.ApplicationGroups");
            DropForeignKey("dbo.ApplicationRoleGroups", "RoleId", "dbo.ApplicationRoles");
            DropForeignKey("dbo.ApplicationUserGroups", "GroupId", "dbo.ApplicationGroups");
            DropForeignKey("dbo.ApplicationUserGroups", "UserId", "dbo.ApplicationUsers");
            DropIndex("dbo.ApplicationRoleGroups", new[] { "GroupId" });
            DropIndex("dbo.ApplicationRoleGroups", new[] { "RoleId" });
            DropIndex("dbo.ApplicationUserGroups", new[] { "UserId" });
            DropIndex("dbo.ApplicationUserGroups", new[] { "GroupId" });
            DropTable("dbo.ApplicationGroups");
            DropTable("dbo.ApplicationRoleGroups");
            DropTable("dbo.ApplicationUserGroups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserGroups",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId });
            
            CreateTable(
                "dbo.ApplicationRoleGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GroupId, t.RoleId });
            
            CreateTable(
                "dbo.ApplicationGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.ApplicationUserGroups", "GroupId");
            CreateIndex("dbo.ApplicationUserGroups", "UserId");
            CreateIndex("dbo.ApplicationRoleGroups", "RoleId");
            CreateIndex("dbo.ApplicationRoleGroups", "GroupId");
            AddForeignKey("dbo.ApplicationUserGroups", "UserId", "dbo.ApplicationUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserGroups", "GroupId", "dbo.ApplicationGroups", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationRoleGroups", "RoleId", "dbo.ApplicationRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationRoleGroups", "GroupId", "dbo.ApplicationGroups", "ID", cascadeDelete: true);
        }
    }
}
