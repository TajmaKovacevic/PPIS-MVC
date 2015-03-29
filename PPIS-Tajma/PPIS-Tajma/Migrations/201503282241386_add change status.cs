namespace PPIS_Tajma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addchangestatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChangeTicketModels", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.ChangeTicketModels", "Assigned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChangeTicketModels", "Assigned");
            DropColumn("dbo.ChangeTicketModels", "Status");
        }
    }
}
