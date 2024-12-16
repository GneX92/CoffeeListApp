namespace CoffeeList.Models;

public class Entry( string name )
{
    public int Id { get; set; }

    public string? Name { get; set; } = name;

    public int Count { get; set; } = 1;
}