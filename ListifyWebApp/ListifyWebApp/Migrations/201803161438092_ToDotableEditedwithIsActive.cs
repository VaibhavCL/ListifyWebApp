namespace ListifyWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    /// <summary>
    /// This is an new update for migration
    /// </summary>
    public partial class ToDotableEditedwithIsActive : DbMigration
    {
        /// <summary>
        /// This is an new update for migration
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.ToDoes", "IsActive", c => c.Boolean(nullable: false));
        }
        /// <summary>
        /// This is an old update for migration
        /// </summary>
        public override void Down()
        {
            DropColumn("dbo.ToDoes", "IsActive");
        }
    }
}
