namespace DungeonCrawler;

public class Weapon : Item
{
    public float Damage { get; private set; }
    
    public Weapon(string name, float damage = 5) : base(name)
    {
        Damage = damage;
    }
}