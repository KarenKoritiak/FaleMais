namespace FaleMais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cidades", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.FaleMaisPlanos", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FaleMaisPlanos", "Nome", c => c.String());
            AlterColumn("dbo.Cidades", "Nome", c => c.String());
        }
    }
}
