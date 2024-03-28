using Mycloth_website.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.NewFolder
{
    public class ApplicationDbContex:DbContext
    {
        public ApplicationDbContex()
        {
            
        }
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options) : base(options) 
        { 

        }
        public DbSet<MenCategory> MenCategory { get; set; }
        public DbSet<WomenCategory> WomenCategory { get; set; }
        public DbSet<ShoesCategory> ShoesCategory { get; set; }
        public DbSet<ElectronicsCategory> ElectronicsCategory { get; set; }
        public DbSet<FrunitureCategory> FrunitureCategory { get; set; }
        public DbSet<CleaningCategory> CleaningCategory { get; set; }
        public DbSet<tvCategory> tvCategory { get; set; }
        public DbSet<ToysCategory> ToysCategory { get; set; }
        public DbSet<MobileCategory> MobileCategory { get; set; }
        public DbSet<Cart> Cart { get; set; }
    }
}
