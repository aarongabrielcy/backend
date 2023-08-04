namespace adminApi.Models;

public class Vehicle
{

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Alias { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? Year { get; set; }
    public int DeviceId { get; set; }
    public double fuelEfficiency { get; set; } = 0;
    public double fuelTankCapacity { get; set; } = 0;
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; } = DateTime.Now;
    public int userCreate { get; set; } = 1;
    public int userUpdate { get; set; } = 1;
    public bool Active { get; set; } = false;
}