namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v106 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Candidates", "birthDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("Candidates", "birthDate", c => c.DateTime(nullable: false, precision: 0));
        }
    }
}
