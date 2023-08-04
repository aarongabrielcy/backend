namespace adminApi.Models;

public class VehicleDTO {
    public int Id { get; set; }
    public long Name { get; set; }
    public long Alias { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? Year { get; set; }
    public int DeviceId  {get; set;}
    public Device Device  {get; set;}
    public double fuelEfficiency {get; set;}
    public double fuelTankCapacity  {get; set;}
}