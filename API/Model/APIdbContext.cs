using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace BackendAPI.Model
{
    public partial class APIdbContext : DbContext
    {
        public APIdbContext() { }
        public APIdbContext(DbContextOptions<APIdbContext> options)
        : base(options)
        { }

        public virtual DbSet<Employee> employee { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-8NILL7B2\\HEMANT;Database=demoDB;Integrated Security=sspi;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.FirstName).HasColumnName("firstname");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public void Save()
        {
            this.SaveChanges();
        }
    }
}
