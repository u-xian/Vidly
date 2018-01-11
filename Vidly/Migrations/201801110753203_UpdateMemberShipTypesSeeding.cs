namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberShipTypesSeeding : DbMigration
    {
        public override void Up()
        {
            Sql(" UPDATE MemberShipTypes SET NAME='Pay as You Go' where Id=1");
            Sql(" UPDATE MemberShipTypes SET NAME='Monthly' where Id=2");
            Sql(" UPDATE MemberShipTypes SET NAME='Quarterly' where Id=3");
            Sql(" UPDATE MemberShipTypes SET NAME='Annual' where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
