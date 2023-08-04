namespace adminApi.Models;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LasstName { get; set; }
    public string Email { get; set; }
    public string License { get; set; }
    public string Phone { get; set; }
    public string SecundaryPhone { get; set; }
    public string Type { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; } = DateTime.Now;
    public int userCreate { get; set; } = 1;
    public int userUpdate { get; set; } = 1;
    public bool Active { get; set; } = false;

}