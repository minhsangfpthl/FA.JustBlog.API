namespace FA.JustBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixChangeModelPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("common.Posts", "ViewCount", c => c.Int(nullable: false));
            AddColumn("common.Posts", "RateCount", c => c.Int(nullable: false));
            AddColumn("common.Posts", "TotalRate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("common.Posts", "TotalRate");
            DropColumn("common.Posts", "RateCount");
            DropColumn("common.Posts", "ViewCount");
        }
    }
}
