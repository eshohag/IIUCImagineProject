namespace IIUCImagineProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialState : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tittle = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DoYouKnows",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tittle = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ContactNo = c.String(nullable: false, maxLength: 11),
                        StudentID = c.String(nullable: false, maxLength: 7),
                        Email = c.String(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        DoYouKnowID = c.Int(nullable: false),
                        ParticipateID = c.Int(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.DoYouKnows", t => t.DoYouKnowID, cascadeDelete: true)
                .ForeignKey("dbo.Participates", t => t.ParticipateID, cascadeDelete: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.DoYouKnowID)
                .Index(t => t.ParticipateID);
            
            CreateTable(
                "dbo.Participates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tittle = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "ParticipateID", "dbo.Participates");
            DropForeignKey("dbo.Members", "DoYouKnowID", "dbo.DoYouKnows");
            DropForeignKey("dbo.Members", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.Members", new[] { "ParticipateID" });
            DropIndex("dbo.Members", new[] { "DoYouKnowID" });
            DropIndex("dbo.Members", new[] { "DepartmentID" });
            DropTable("dbo.Participates");
            DropTable("dbo.Members");
            DropTable("dbo.DoYouKnows");
            DropTable("dbo.Departments");
        }
    }
}
