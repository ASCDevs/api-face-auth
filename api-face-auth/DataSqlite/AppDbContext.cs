using Microsoft.EntityFrameworkCore;
using api_face_auth.DataSqlite.Entities;

namespace api_face_auth.DataSqlite
{
    public class AppDbContext : DbContext{
        public DbSet<User> Users { get; set; }
        public DbSet<UserFace> UsersFace {get;set;}

        //Configurar depois no appSettings
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}