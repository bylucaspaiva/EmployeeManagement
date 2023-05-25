using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<JobTitle> JobTitles { get; set; }
    //public class Tcontext
    //{
    //    public string? CNPJ { get; set; }
    //    public string EmployeeId { get; set; }
    //    public string JobId { get; set; }
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Company)
            .WithMany(c => c.Employees)
            .HasForeignKey(e => e.CompanyCNPJ);

        modelBuilder.Entity<JobTitle>()
            .HasOne(j => j.Employee)
            .WithMany(j => j.JobHistory)
            .HasForeignKey(j => j.EmployeeId);

    }
}
