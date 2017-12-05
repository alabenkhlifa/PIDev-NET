namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v100 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "plainpassword",
                c => new
                    {
                        idPlain = c.Int(nullable: false, identity: true),
                        Password = c.String(maxLength: 255, unicode: false),
                        Username = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.idPlain);
            
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
                        Id = c.Int(nullable: false),
                        adresse = c.String(maxLength: 255, unicode: false),
                        email = c.String(maxLength: 255, unicode: false),
                        firstname = c.String(maxLength: 255, unicode: false),
                        gender = c.String(maxLength: 255, unicode: false),
                        lastname = c.String(maxLength: 255, unicode: false),
                        password = c.String(maxLength: 255, unicode: false),
                        phoneNumber = c.String(maxLength: 255, unicode: false),
                        picture = c.Binary(),
                        role = c.String(maxLength: 255, unicode: false),
                        state = c.Int(),
                        username = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("user");
            DropTable("t_token");
            DropTable("plainpassword");
        }
    }
}
