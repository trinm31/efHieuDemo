using efHieuDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace efHieuDemo.DbContext;

public class ApplicationDbContext: Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<People> Peoples { get; set; }

    public DbSet<Test> Tests { get; set; }
    public DbSet<Address> Addresses { get; set; }
}