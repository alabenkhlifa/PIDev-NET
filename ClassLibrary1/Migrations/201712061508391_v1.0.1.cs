namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v101 : DbMigration
    {
        public override void Up()
        {
            //MoveTable(name: "plainpassword", newSchema: "dbo");
            //MoveTable(name: "t_token", newSchema: "dbo");
            //MoveTable(name: "user", newSchema: "dbo");
            CreateTable(
                "Candidates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(unicode: false),
                        surname = c.String(unicode: false),
                        birthDate = c.DateTime(nullable: false, precision: 0),
                        age = c.Int(nullable: false),
                        address_country = c.String(unicode: false),
                        address_address = c.String(unicode: false),
                        address_city = c.String(unicode: false),
                        phone = c.String(unicode: false),
                        email = c.String(unicode: false),
                        sex = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "CVs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        candidateId = c.Int(nullable: false),
                        typeofjob = c.String(nullable: false, unicode: false),
                        departement = c.String(nullable: false, unicode: false),
                        linkedInLink = c.String(unicode: false),
                        hobbies = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("Candidates", t => t.candidateId, cascadeDelete: true)
                .Index(t => t.candidateId);
            
            CreateTable(
                "Educations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        from = c.DateTime(nullable: false, precision: 0),
                        to = c.DateTime(nullable: false, precision: 0),
                        title = c.String(unicode: false),
                        organisation_organisationName = c.String(unicode: false),
                        organisation_organisationCity = c.String(unicode: false),
                        organisation_organisationCountry = c.String(unicode: false),
                        CV_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("CVs", t => t.CV_id)
                .Index(t => t.CV_id);
            
            CreateTable(
                "Experiences",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        from = c.DateTime(nullable: false, precision: 0),
                        to = c.DateTime(nullable: false, precision: 0),
                        poste = c.String(unicode: false),
                        company = c.String(unicode: false),
                        CV_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("CVs", t => t.CV_id)
                .Index(t => t.CV_id);
            
            CreateTable(
                "Languages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(unicode: false),
                        level = c.String(unicode: false),
                        CV_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("CVs", t => t.CV_id)
                .Index(t => t.CV_id);
            
            AlterColumn("user", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("user", "phoneNumber", c => c.String(unicode: false));
            AlterColumn("user", "state", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropForeignKey("Languages", "CV_id", "CVs");
            DropForeignKey("Experiences", "CV_id", "CVs");
            DropForeignKey("Educations", "CV_id", "CVs");
            DropForeignKey("CVs", "candidateId", "Candidates");
            DropIndex("Languages", new[] { "CV_id" });
            DropIndex("Experiences", new[] { "CV_id" });
            DropIndex("Educations", new[] { "CV_id" });
            DropIndex("CVs", new[] { "candidateId" });
            AlterColumn("user", "state", c => c.Int());
            AlterColumn("user", "phoneNumber", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("user", "Id", c => c.Int(nullable: false));
            DropTable("Languages");
            DropTable("Experiences");
            DropTable("Educations");
            DropTable("CVs");
            DropTable("Candidates");
            MoveTable(name: "user", newSchema: "userdb");
            MoveTable(name: "t_token", newSchema: "userdb");
            MoveTable(name: "plainpassword", newSchema: "userdb");
        }
    }
}
