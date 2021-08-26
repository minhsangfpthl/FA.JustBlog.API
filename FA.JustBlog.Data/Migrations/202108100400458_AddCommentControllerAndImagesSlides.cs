namespace FA.JustBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentControllerAndImagesSlides : DbMigration
    {
        public override void Up()
        {
            AddColumn("common.Posts", "ImageSlider", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("common.Posts", "ImageSlider");
        }
    }
}
