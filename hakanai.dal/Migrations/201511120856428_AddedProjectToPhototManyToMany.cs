namespace hakanai.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProjectToPhototManyToMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectPhotograh",
                c => new
                    {
                        ProjectRefId = c.Guid(nullable: false),
                        PhotographRefId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectRefId, t.PhotographRefId })
                .ForeignKey("dbo.Projects", t => t.ProjectRefId, cascadeDelete: true)
                .ForeignKey("dbo.Photographs", t => t.PhotographRefId, cascadeDelete: true)
                .Index(t => t.ProjectRefId)
                .Index(t => t.PhotographRefId);
            
            AlterColumn("dbo.Projects", "ProjectId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Projects", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectPhotograh", "PhotographRefId", "dbo.Photographs");
            DropForeignKey("dbo.ProjectPhotograh", "ProjectRefId", "dbo.Projects");
            DropIndex("dbo.ProjectPhotograh", new[] { "PhotographRefId" });
            DropIndex("dbo.ProjectPhotograh", new[] { "ProjectRefId" });
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "ProjectId", c => c.Guid(nullable: false, identity: true));
            DropTable("dbo.ProjectPhotograh");
        }
    }
}
