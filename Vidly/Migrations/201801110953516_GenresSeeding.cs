namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenresSeeding : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRETYPES (Name) VALUES ('Comedy')");
            Sql("INSERT INTO GENRETYPES (Name) VALUES ('Action')");
            Sql("INSERT INTO GENRETYPES (Name) VALUES ('Family')");
            Sql("INSERT INTO GENRETYPES (Name) VALUES ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
