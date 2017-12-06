namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v103 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("Educations", "cv_id", "CVs");
            //DropForeignKey("Languages", "CV_id", "CVs");
            DropIndex("Educations", new[] { "cv_id" });
            DropIndex("Languages", new[] { "CV_id" });
            AlterColumn("Educations", "CV_id", c => c.Int());
            AlterColumn("Languages", "cv_id", c => c.Int(nullable: false));
            CreateIndex("Educations", "CV_id");
            CreateIndex("Languages", "cv_id");
            AddForeignKey("Educations", "CV_id", "CVs", "id");
            AddForeignKey("Languages", "cv_id", "CVs", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Languages", "cv_id", "CVs");
            DropForeignKey("Educations", "CV_id", "CVs");
            DropIndex("Languages", new[] { "cv_id" });
            DropIndex("Educations", new[] { "CV_id" });
            AlterColumn("Languages", "cv_id", c => c.Int());
            AlterColumn("Educations", "CV_id", c => c.Int());
            CreateIndex("Languages", "CV_id");
            CreateIndex("Educations", "cv_id");
            AddForeignKey("Languages", "CV_id", "CVs", "id");
            AddForeignKey("Educations", "cv_id", "CVs", "id");
        }
    }
}
