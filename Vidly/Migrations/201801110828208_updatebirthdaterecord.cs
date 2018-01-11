namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebirthdaterecord : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET birthdate='' where id=3");
        }
        
        public override void Down()
        {
        }
    }
}
