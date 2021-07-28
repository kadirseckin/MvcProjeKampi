namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_about : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutTitle", c => c.String(maxLength: 100));
            AddColumn("dbo.Abouts", "AboutText", c => c.String(maxLength: 1000));
            DropColumn("dbo.Abouts", "AboutDetailsFirst");
            DropColumn("dbo.Abouts", "AboutDetailsSecond");
            DropColumn("dbo.Abouts", "AboutImageFirst");
            DropColumn("dbo.Abouts", "AboutImageSecond");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "AboutImageSecond", c => c.String(maxLength: 100));
            AddColumn("dbo.Abouts", "AboutImageFirst", c => c.String(maxLength: 100));
            AddColumn("dbo.Abouts", "AboutDetailsSecond", c => c.String(maxLength: 1000));
            AddColumn("dbo.Abouts", "AboutDetailsFirst", c => c.String(maxLength: 1000));
            DropColumn("dbo.Abouts", "AboutText");
            DropColumn("dbo.Abouts", "AboutTitle");
        }
    }
}
