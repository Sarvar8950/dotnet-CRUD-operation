using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using practiceApi.Models;

namespace practiceApi.Data
{
    public class ApplicationDbContext : DbContext
    {
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {
        
    }
    public DbSet<Stock> Stock { get; set; }
    public DbSet<Comments> Comment { get; set; }
    public DbSet<User> User { get; set; }
        
    }
}