using Microsoft.EntityFrameworkCore;

namespace Blog.Models
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext() { }
        public BlogDBContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = "server=localhost; database=Blog; user=root; password=";

                optionsBuilder.UseMySQL(conn);
            }
        }
        public DbSet<Blogger> Bloggers { get; set; } = null;
    }
}
