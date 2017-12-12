namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1111 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("CVs", "typeofjob", c => c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("CVs", "typeofjob", c => c.String(nullable: false, maxLength: 15, unicode: false, storeType: "nvarchar"));
        }
    }
}
