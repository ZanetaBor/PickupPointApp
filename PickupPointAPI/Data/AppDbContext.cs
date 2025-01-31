using Microsoft.EntityFrameworkCore;
using PickupPointAPI.Models;

namespace PickupPointAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PickupPoint> PickupPoints { get; set; }
    }
}
