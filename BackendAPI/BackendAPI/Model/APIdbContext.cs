using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BackendAPI.Model
{
    public class APIdbContext : DbContext
    {
        public APIdbContext(DbContextOptions<APIdbContext> options)
        : base(options)
        { }

        //public DbSet<Blog> Blogs { get; set; }
    }
}
