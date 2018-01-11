namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsMoviesandGenres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ReleasedDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        NumberStock = c.Int(nullable: false),
                        GenreTypesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GenreTypes", t => t.GenreTypesId, cascadeDelete: true)
                .Index(t => t.GenreTypesId);
            
            CreateTable(
                "dbo.GenreTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreTypesId", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreTypesId" });
            DropTable("dbo.GenreTypes");
            DropTable("dbo.Movies");
        }
    }
}
