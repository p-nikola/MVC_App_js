namespace HospitalMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeHospitalIdNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "HospitalId", "dbo.Hospitals");
            DropIndex("dbo.Doctors", new[] { "HospitalId" });
            AlterColumn("dbo.Doctors", "HospitalId", c => c.Int());
            CreateIndex("dbo.Doctors", "HospitalId");
            AddForeignKey("dbo.Doctors", "HospitalId", "dbo.Hospitals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "HospitalId", "dbo.Hospitals");
            DropIndex("dbo.Doctors", new[] { "HospitalId" });
            AlterColumn("dbo.Doctors", "HospitalId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "HospitalId");
            AddForeignKey("dbo.Doctors", "HospitalId", "dbo.Hospitals", "Id", cascadeDelete: true);
        }
    }
}
