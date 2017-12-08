namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v102 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Educations", "CV_id", "CVs");
            DropIndex("Educations", new[] { "CV_id" });
            AlterColumn("Educations", "cv_id", c => c.Int());
            CreateIndex("Educations", "cv_id");
            AddForeignKey("Educations", "cv_id", "CVs", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("Educations", "cv_id", "CVs");
            DropIndex("Educations", new[] { "cv_id" });
            AlterColumn("Educations", "cv_id", c => c.Int());
            CreateIndex("Educations", "CV_id");
            AddForeignKey("Educations", "CV_id", "CVs", "id");
        }
    }
}
