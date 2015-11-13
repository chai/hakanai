namespace hakanai.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photographs", "location", c => c.String(nullable: false));
            AlterColumn("dbo.Photographs", "PhotographyId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Photographs", "PhotographyId", c => c.Guid(nullable: false));
            DropColumn("dbo.Photographs", "location");
        }
    }
}
