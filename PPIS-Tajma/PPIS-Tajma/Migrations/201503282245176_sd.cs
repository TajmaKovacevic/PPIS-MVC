namespace PPIS_Tajma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ChangeTicketModels", "Assigned");
            DropColumn("dbo.TicketModels", "Assigned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketModels", "Assigned", c => c.Boolean(nullable: false));
            AddColumn("dbo.ChangeTicketModels", "Assigned", c => c.Boolean(nullable: false));
        }
    }
}
