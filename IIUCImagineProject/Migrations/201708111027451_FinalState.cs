namespace IIUCImagineProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalState : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "ContactNo", c => c.String(nullable: false, maxLength: 14));
            AlterColumn("dbo.Members", "StudentID", c => c.String(nullable: false, maxLength: 9));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "StudentID", c => c.String(nullable: false, maxLength: 7));
            AlterColumn("dbo.Members", "ContactNo", c => c.String(nullable: false, maxLength: 11));
        }
    }
}
