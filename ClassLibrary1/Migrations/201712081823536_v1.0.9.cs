namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v109 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Candidates", "email", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("Candidates", "email", c => c.String(unicode: false));
        }
    }
}
