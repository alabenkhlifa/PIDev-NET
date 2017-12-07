namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v107 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Educations", "from", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("Educations", "to", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("Experiences", "from", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("Experiences", "to", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("Experiences", "to", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("Experiences", "from", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("Educations", "to", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("Educations", "from", c => c.DateTime(nullable: false, precision: 0));
        }
    }
}
