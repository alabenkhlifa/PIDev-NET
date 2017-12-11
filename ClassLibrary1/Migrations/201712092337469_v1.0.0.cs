namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v100 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Candidates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 25, storeType: "nvarchar"),
                        surname = c.String(maxLength: 25, storeType: "nvarchar"),
                        birthDate = c.DateTime(nullable: false, storeType: "date"),
                        age = c.Int(nullable: false),
                        address_country = c.String(maxLength: 25, storeType: "nvarchar"),
                        address_address = c.String(maxLength: 25, storeType: "nvarchar"),
                        address_city = c.String(maxLength: 25, storeType: "nvarchar"),
                        phone = c.String(maxLength: 25, storeType: "nvarchar"),
                        email = c.String(maxLength: 50, storeType: "nvarchar"),
                        sex = c.String(maxLength: 25, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "Collects",
                c => new
                    {
                        CollectID = c.Int(nullable: false, identity: true),
                        CollectImg = c.String(unicode: false),
                        CollectName = c.String(nullable: false, unicode: false),
                        CollectDescription = c.String(unicode: false),
                        CollectType = c.String(unicode: false),
                        CollectDateD = c.DateTime(nullable: false, precision: 0),
                        CollectTime = c.DateTime(nullable: false, precision: 0),
                        NombreParticiapant = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CollectID);
            
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
                        from = c.DateTime(nullable: false, storeType: "date"),
                        to = c.DateTime(nullable: false, storeType: "date"),
                        title = c.String(maxLength: 25, storeType: "nvarchar"),
                        organisation_Name = c.String(maxLength: 25, storeType: "nvarchar"),
                        organisation_City = c.String(maxLength: 25, storeType: "nvarchar"),
                        organisation_Country = c.String(maxLength: 25, storeType: "nvarchar"),
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
                        from = c.DateTime(nullable: false, storeType: "date"),
                        to = c.DateTime(nullable: false, storeType: "date"),
                        poste = c.String(maxLength: 25, storeType: "nvarchar"),
                        company = c.String(maxLength: 25, storeType: "nvarchar"),
                        cv_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("CVs", t => t.cv_id, cascadeDelete: true)
                .Index(t => t.cv_id);
            
            CreateTable(
                "Languages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 25, storeType: "nvarchar"),
                        level = c.String(maxLength: 25, storeType: "nvarchar"),
                        cv_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("CVs", t => t.cv_id, cascadeDelete: true)
                .Index(t => t.cv_id);
            
            CreateTable(
                "t_token",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        expiration = c.DateTime(precision: 0),
                        value = c.String(maxLength: 255, unicode: false),
                        user_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "user",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        adresse = c.String(maxLength: 255, unicode: false),
                        email = c.String(maxLength: 255, unicode: false),
                        firstname = c.String(maxLength: 255, unicode: false),
                        gender = c.String(maxLength: 255, unicode: false),
                        lastname = c.String(maxLength: 255, unicode: false),
                        password = c.String(maxLength: 255, unicode: false),
                        phoneNumber = c.String(unicode: false),
                        picture = c.Binary(),
                        role = c.String(maxLength: 255, unicode: false),
                        state = c.Boolean(),
                        username = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Languages", "cv_id", "CVs");
            DropForeignKey("Experiences", "cv_id", "CVs");
            DropForeignKey("Educations", "CV_id", "CVs");
            DropForeignKey("CVs", "candidateId", "Candidates");
            DropIndex("Languages", new[] { "cv_id" });
            DropIndex("Experiences", new[] { "cv_id" });
            DropIndex("Educations", new[] { "CV_id" });
            DropIndex("CVs", new[] { "candidateId" });
            DropTable("user");
            DropTable("t_token");
            DropTable("Languages");
            DropTable("Experiences");
            DropTable("Educations");
            DropTable("CVs");
            DropTable("Collects");
            DropTable("Candidates");
        }
    }
}
