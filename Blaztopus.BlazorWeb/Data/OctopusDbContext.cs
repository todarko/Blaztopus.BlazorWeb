using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Blaztopus.BlazorWeb.Models;

namespace Blaztopus.BlazorWeb.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<OctopusDbContext>
    {
        public OctopusDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OctopusDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-Blaztopus.BlazorWeb-50ACFE10-FA38-48A8-9307-EE0484C8ACDC;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new OctopusDbContext(optionsBuilder.Options);
        }
    }

    public class OctopusDbContext : DbContext
    {
        public OctopusDbContext(DbContextOptions<OctopusDbContext> options)
            : base(options)
        {
        }
        public DbSet<Form> Forms { get; set; }
    }
}
