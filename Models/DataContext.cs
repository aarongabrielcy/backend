using Microsoft.EntityFrameworkCore;

namespace adminApi.Models;

public class DataContext : DbContext {
    protected readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration){
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Database"));
    }
    public DbSet<Device> Devices { get; set; } = null!;
    public DbSet<Vehicle> Vehicles { get; set; } = null!;

}