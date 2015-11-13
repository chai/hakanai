namespace hakanai.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photographs",
                c => new
                    {
                        PhotographyId = c.Guid(nullable: false),
                        title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PhotographyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Photographs");
        }
    }
}
