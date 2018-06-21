namespace ListifyWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /// <summary>
    /// 
    /// </summary>
    public partial class updateuseridtostring : DbMigration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            DropIndex("dbo.ToDoMappings", new[] { "User_Id" });
            DropColumn("dbo.ToDoMappings", "UserId");
            RenameColumn(table: "dbo.ToDoMappings", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.ToDoMappings", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ToDoMappings", "UserId");
        }
        
        /// <summary>
        /// 
        /// </summary>
        public override void Down()
        {
            DropIndex("dbo.ToDoMappings", new[] { "UserId" });
            AlterColumn("dbo.ToDoMappings", "UserId", c => c.Long(nullable: false));
            RenameColumn(table: "dbo.ToDoMappings", name: "UserId", newName: "User_Id");
            AddColumn("dbo.ToDoMappings", "UserId", c => c.Long(nullable: false));
            CreateIndex("dbo.ToDoMappings", "User_Id");
        }
    }
}
