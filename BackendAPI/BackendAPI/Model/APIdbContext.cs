using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System;
using Microsoft.IdentityModel.Protocols;

namespace BackendAPI.Model
{
    public partial class APIdbContext : DbContext
    {
        public APIdbContext() { }
        public APIdbContext(DbContextOptions<APIdbContext> options)
        : base(options)
        { }

        //public virtual DbSet<Blog> Blogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["Adb"].ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<user>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("Id");
            //});
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public void Save()
        {
            this.SaveChanges();
        }
    }
}
