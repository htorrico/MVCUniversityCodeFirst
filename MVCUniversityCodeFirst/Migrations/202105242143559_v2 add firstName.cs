namespace MVCUniversityCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2addfirstName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "FirstName");
        }
    }
}
