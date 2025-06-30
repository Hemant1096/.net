using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BackendAPI.Authentication;

namespace BackendAPI.Model
{
    public partial class APIdbContext : IdentityDbContext<ApplicationUser>
    {
        public APIdbContext() { }
        public APIdbContext(DbContextOptions<APIdbContext> options)
        : base(options)
        { }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public void Save()
        {
            this.SaveChanges();
        }
    }
}
