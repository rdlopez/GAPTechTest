namespace GAPTechTest.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialConfiguration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hedges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Percentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        Period = c.Int(nullable: false),
                        RiskType = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Hedge_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hedges", t => t.Hedge_Id)
                .Index(t => t.Hedge_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Policies", "Hedge_Id", "dbo.Hedges");
            DropIndex("dbo.Policies", new[] { "Hedge_Id" });
            DropTable("dbo.Policies");
            DropTable("dbo.Hedges");
        }
    }
}
