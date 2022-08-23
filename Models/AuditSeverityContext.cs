using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AuditSeverityModule.Models
{
    public class AuditSeverityContext:DbContext
    {
        string connectionString = "Server=tcp:db-checklist.database.windows.net,1433;Initial Catalog=AuditSeverity;Persist Security Info=False;User ID=azureroot;Password=@12Shubho@12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public DbSet<AuditBenchmark> AuditBenchmarks { get; set; }
        public DbSet<AuditDetail> AuditDetails { get; set; }
        public DbSet<AuditRequest> AuditRequests { get; set; }
        public DbSet<AuditResponse> AuditResponses { get; set; }
        public DbSet<Questions> Questions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditDetail>().HasKey(x => new { x.AuditDetailId });
        }

    }
}
