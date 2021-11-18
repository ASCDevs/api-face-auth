using Microsoft.EntityFrameworkCore;
using api_face_auth.DataSqlite.Entities;

namespace api_face_auth.DataSqlite
{
    public class AppDbContext : DbContext{

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserFace> UsersFace { get; set; }

    }
}