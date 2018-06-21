namespace ListifyWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /// <summary>
    /// This is an new update for the migration
    /// </summary>
    public partial class ToDoMappingUpdatedIsDeletedtoIsActive : DbMigration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.ToDoMappings", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.ToDoMappings", "IsDeleted");
        }
        
        /// <summary>
        /// This is an old update for the migration
        /// </summary>
        public override void Down()
        {
            AddColumn("dbo.ToDoMappings", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.ToDoMappings", "IsActive");
        }
    }
}
