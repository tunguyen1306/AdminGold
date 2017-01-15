namespace ApiManga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAdvertMangas",
                c => new
                    {
                        IdAdvertManga = c.Int(nullable: false),
                        NameAdvertManga = c.String(maxLength: 500),
                        DesAdvertManga = c.String(maxLength: 4000),
                        NameAuthorAdvertManga = c.String(maxLength: 500),
                        StatusAdvertManga = c.Int(),
                        StatusChapAdvertManga = c.Int(),
                        CountChapAdvertManga = c.Int(),
                        TypeAdvertManga = c.Int(),
                        ImgAdvertManga = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.IdAdvertManga);
            
            CreateTable(
                "dbo.tblTypeMangas",
                c => new
                    {
                        IdTypeManga = c.Int(nullable: false),
                        NameTypeManga = c.String(maxLength: 500),
                        StatusTypeManga = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTypeManga);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblTypeMangas");
            DropTable("dbo.tblAdvertMangas");
        }
    }
}
