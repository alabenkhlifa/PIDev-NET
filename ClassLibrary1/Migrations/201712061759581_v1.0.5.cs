namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v105 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Candidates", "name", c => c.String(maxLength: 25, unicode: false, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("Candidates", "name", c => c.String(unicode: false));
        }
    }
}
