namespace PPIS_Tajma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstatustoticket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChangeTicketModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        UserName = c.String(),
                        Location = c.String(),
                        Steps = c.String(),
                        Actions = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TicketModels", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.TicketModels", "Assigned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TicketModels", "Assigned");
            DropColumn("dbo.TicketModels", "Status");
            DropTable("dbo.ChangeTicketModels");
        }
    }
}
