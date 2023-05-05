namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStatistic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Statistic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatisticTime = c.DateTime(nullable: false),
                        AccessNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tb_Product", "ViewCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "ViewCount");
            DropTable("dbo.Statistic");
        }
    }
}
