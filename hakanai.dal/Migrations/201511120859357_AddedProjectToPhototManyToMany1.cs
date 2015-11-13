namespace hakanai.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProjectToPhototManyToMany1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "ProjectId", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Title", c => c.String());
            AlterColumn("dbo.Projects", "ProjectId", c => c.Guid(nullable: false));
        }
    }
}
