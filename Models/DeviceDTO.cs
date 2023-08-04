namespace adminApi.Models;

public class DeviceDTO {
 public int Id { get; set; }
    public long Imei { get; set; }
    public string? Model { get; set; }
    public DateTime UpdateAt { get; set;}
    public bool Active { get; set; }
}