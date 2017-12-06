namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v104 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("Experiences", "CV_id", "CVs");
            DropIndex("Experiences", new[] { "CV_id" });
            AlterColumn("Experiences", "cv_id", c => c.Int(nullable: false));
            CreateIndex("Experiences", "cv_id");
            AddForeignKey("Experiences", "cv_id", "CVs", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Experiences", "cv_id", "CVs");
            DropIndex("Experiences", new[] { "cv_id" });
            AlterColumn("Experiences", "cv_id", c => c.Int());
            CreateIndex("Experiences", "CV_id");
            AddForeignKey("Experiences", "CV_id", "CVs", "id");
        }
    }
}
