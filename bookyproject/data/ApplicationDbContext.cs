using bookyproject.Models;
using Microsoft.EntityFrameworkCore;

namespace bookyproject.data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        public DbSet<Category> Categories {get; set;}


    }
}
