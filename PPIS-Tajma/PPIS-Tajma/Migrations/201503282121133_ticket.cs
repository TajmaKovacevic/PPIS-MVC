namespace PPIS_Tajma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ticket : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TicketModels", "Title", c => c.String(nullable: false));
            DropColumn("dbo.TicketModels", "ContactPerson");
            DropColumn("dbo.TicketModels", "ContactNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketModels", "ContactNumber", c => c.String());
            AddColumn("dbo.TicketModels", "ContactPerson", c => c.String());
            AlterColumn("dbo.TicketModels", "Title", c => c.String());
        }
    }
}
