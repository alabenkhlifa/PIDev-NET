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
                "dbo.Candidates",
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
                "dbo.CVs",
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
                .ForeignKey("dbo.Candidates", t => t.candidateId, cascadeDelete: true)
                .Index(t => t.candidateId);
            
            CreateTable(
                "dbo.Educations",
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
                .ForeignKey("dbo.CVs", t => t.CV_id)
                .Index(t => t.CV_id);
            
            CreateTable(
                "dbo.Experiences",
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
                .ForeignKey("dbo.CVs", t => t.CV_id)
                .Index(t => t.CV_id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(unicode: false),
                        level = c.String(unicode: false),
                        CV_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CVs", t => t.CV_id)
                .Index(t => t.CV_id);
            
            AlterColumn("dbo.user", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.user", "phoneNumber", c => c.String(unicode: false));
            AlterColumn("dbo.user", "state", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropForeignKey("Languages", "CV_id", "CVs");
            DropForeignKey("dbo.Experiences", "CV_id", "dbo.CVs");
            DropForeignKey("dbo.Educations", "CV_id", "dbo.CVs");
            DropForeignKey("dbo.CVs", "candidateId", "dbo.Candidates");
            DropIndex("dbo.Languages", new[] { "CV_id" });
            DropIndex("dbo.Experiences", new[] { "CV_id" });
            DropIndex("dbo.Educations", new[] { "CV_id" });
            DropIndex("dbo.CVs", new[] { "candidateId" });
            AlterColumn("dbo.user", "state", c => c.Int());
            AlterColumn("dbo.user", "phoneNumber", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.user", "Id", c => c.Int(nullable: false));
            DropTable("dbo.Languages");
            DropTable("dbo.Experiences");
            DropTable("dbo.Educations");
            DropTable("dbo.CVs");
            DropTable("dbo.Candidates");
            MoveTable(name: "dbo.user", newSchema: "userdb");
            MoveTable(name: "dbo.t_token", newSchema: "userdb");
            MoveTable(name: "dbo.plainpassword", newSchema: "userdb");
        }
    }
}
