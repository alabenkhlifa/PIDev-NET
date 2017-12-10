namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1010 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("user", "state", c => c.String(maxLength: 10, unicode: false, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("user", "state", c => c.Boolean());
        }
    }
}
