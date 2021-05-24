namespace MVCUniversityCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3addcreditstocourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Credits", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Credits");
        }
    }
}
