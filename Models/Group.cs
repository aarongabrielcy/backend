namespace adminApi.Models;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Company { get; set; }
    public string Contact { get; set; }
    public string Address { get; set; }
    public string SecundaryAddress { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; } = DateTime.Now;
    public int userCreate { get; set; } = 1;
    public int userUpdate { get; set; } = 1;
    public bool Active { get; set; } = false;

}