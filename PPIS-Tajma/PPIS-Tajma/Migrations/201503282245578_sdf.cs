namespace PPIS_Tajma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChangeTicketModels", "Assigned", c => c.String());
            AddColumn("dbo.TicketModels", "Assigned", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TicketModels", "Assigned");
            DropColumn("dbo.ChangeTicketModels", "Assigned");
        }
    }
}
