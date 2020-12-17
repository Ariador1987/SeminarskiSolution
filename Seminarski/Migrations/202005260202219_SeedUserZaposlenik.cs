namespace Seminarski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUserZaposlenik : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0d544383-1cd1-4804-ac12-8c0e2aa3d0c6', N'zaposlenik@seminarski.com', 0, N'AIwoaOjeI0MHUYi8/fBOT2uCltgs6Y10cAv70RtyIlqz5t+GuUMk5nHshBuz7HiBJg==', N'735e160e-0b89-44a6-894d-13e27ebd7f05', NULL, 0, 0, NULL, 1, 0, N'zaposlenik@seminarski.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'80fdb26e-b0ee-4139-937c-9a42503efb4b', N'Zaposlenik')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0d544383-1cd1-4804-ac12-8c0e2aa3d0c6', N'80fdb26e-b0ee-4139-937c-9a42503efb4b')
");
        }
        
        public override void Down()
        {
        }
    }
}
