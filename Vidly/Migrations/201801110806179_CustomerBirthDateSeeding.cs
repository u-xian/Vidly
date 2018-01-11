namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerBirthDateSeeding : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET birthdate='1980-09-26' where id=1");
            Sql("UPDATE Customers SET birthdate='1978-05-14' where id=2");
            Sql("UPDATE Customers SET birthdate='1990-12-29' where id=3");
            Sql("UPDATE Customers SET birthdate='1984-08-06' where id=4");

        }
        
        public override void Down()
        {
        }
    }
}
