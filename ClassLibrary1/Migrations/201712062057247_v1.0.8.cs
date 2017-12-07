namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v108 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Educations", "organisation_Name", c => c.String(unicode: false));
            AddColumn("Educations", "organisation_City", c => c.String(unicode: false));
            AddColumn("Educations", "organisation_Country", c => c.String(unicode: false));
            DropColumn("Educations", "organisation_organisationName");
            DropColumn("Educations", "organisation_organisationCity");
            DropColumn("Educations", "organisation_organisationCountry");
        }
        
        public override void Down()
        {
            AddColumn("Educations", "organisation_organisationCountry", c => c.String(unicode: false));
            AddColumn("Educations", "organisation_organisationCity", c => c.String(unicode: false));
            AddColumn("Educations", "organisation_organisationName", c => c.String(unicode: false));
            DropColumn("Educations", "organisation_Country");
            DropColumn("Educations", "organisation_City");
            DropColumn("Educations", "organisation_Name");
        }
    }
}
