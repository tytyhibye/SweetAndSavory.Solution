using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SweetAndSavory.Models;

namespace SweetAndSavory.Models
{
  public class SeeSweetAndSavoryContext : IdentityDbContext<ApplicationUser> 
  {
    public virtual DbSet<Flavor> Flavors { get; set; }
    public DbSet<Treat> Treats { get; set; }
    public DbSet<FlavorTreat> FlavorTreat { get; set; }
    public SeeSweetAndSavoryContext(DbContextOptions options) : base(options) { }
    }
}