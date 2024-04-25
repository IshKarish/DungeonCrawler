namespace DungeonCrawler;

public class Weapon : Item
{
    public float Damage { get; private set; }
    
    public Weapon(string name, string description = "", float damage = 5) : base(name)
    {
        Damage = damage;

        if (description == "") Description = $"Damage enemies by {damage} HP.";
        else Description = description;
    }
    
    public Weapon(string name, float damage = 5, string description = "") : base(name)
    {
        Damage = damage;

        if (description == "") Description = $"Damage enemies by {damage} HP.";
        else Description = description;
    }
}