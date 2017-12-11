namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v110 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Candidates", "phone", c => c.String(maxLength: 10, unicode: false, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("Candidates", "phone", c => c.String(maxLength: 8, unicode: false, storeType: "nvarchar"));
        }
    }
}
