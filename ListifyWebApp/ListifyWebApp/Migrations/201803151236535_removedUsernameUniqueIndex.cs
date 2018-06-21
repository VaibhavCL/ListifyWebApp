namespace ListifyWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /// <summary>
    /// 
    /// </summary>
    public partial class removedUsernameUniqueIndex : DbMigration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            CreateIndex("dbo.AspNetUsers", "UserName", name: "UserNameIndex");
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
        }
    }
}
