namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
               INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7dabec56-d195-4266-9670-e0e7f3b8a4a2', N'admin@vidly.com', 0, N'AFJTXx1qmJbTpMifO+racwxOg2FEx9QIM3ZXTPtJ5uIM8hgRzF2XvNv4XSFvH4X1NQ==', N'183f384c-769f-492f-8a9d-295a41cc6615', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
               INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'84d83870-c8b3-457e-afe9-90e9d8c00f5a', N'guest@vidly.com', 0, N'AIYeNBZDGJ4W9cF5eAYNGmL0z6wwcgYs5CSsXbW1F7kc6KVIc++SYicpLfmIS0El+Q==', N'66ffb89a-e602-40f9-abe2-cf8ad4b7499f', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
               
               INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e1ba842f-7dd4-46f8-8c45-bb3bff0ba639', N'canManageMovies')


               INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7dabec56-d195-4266-9670-e0e7f3b8a4a2', N'e1ba842f-7dd4-46f8-8c45-bb3bff0ba639')

              ");

            
        }
        
        public override void Down()
        {
        }
    }
}
