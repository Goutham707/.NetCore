using FirstProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Data
{

public class DatabaseContext:DbContext
{

public DatabaseContext(DbContextOptions<DatabaseContext> opt): base(opt)
{
    
}

public DbSet<Project> Commands{get;set;}

}

}