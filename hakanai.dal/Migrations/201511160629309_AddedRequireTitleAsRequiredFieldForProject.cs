namespace hakanai.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequireTitleAsRequiredFieldForProject : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Title", c => c.String());
        }
    }
}
