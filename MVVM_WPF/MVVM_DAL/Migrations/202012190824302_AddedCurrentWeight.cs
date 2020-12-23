namespace MVVM_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCurrentWeight : DbMigration
    {
        public override void Up()
        {
            AddColumn("MyWeight.User", "CurrentWeight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("MyWeight.User", "CurrentWeight");
        }
    }
}
