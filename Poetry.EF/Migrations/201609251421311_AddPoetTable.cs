namespace Poetry.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPoetTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Poetry.Poet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Poetry.Poet");
        }
    }
}
