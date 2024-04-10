namespace DungeonCrawler;

public class Inventory
{
    public List<Item> Items { get; private set; }
    public bool HasChanged { get; set; }
    public bool Equipped { get; set; }

    public Inventory()
    {
        Items = new List<Item>();
    }
    
    public void AddItem(Item item)
    {
        Items.Add(item);
        HasChanged = true;
        Equipped = true;
    }

    public void RemoveItem(string name)
    {
        foreach (Item i in Items.ToArray())
        {
            if (i.Name == name)
            {
                RemoveItem(i);
                return;
            }
        }
    }
    
    public void RemoveItem(Item item)
    {
        Items.Remove(item);
        HasChanged = true;
    }

    public Item Item(int number)
    {
        return Items.ToArray()[number - 1];
    }

    public bool HasItem(string name, bool remove = false)
    {
        foreach (Item i in Items.ToArray())
        {
            if (i.Name == name)
            {
                if (remove) RemoveItem(i.Name);
                return true;
            }
        }

        return false;
    }

    public override string ToString()
    {
        if (Items.Count == 0) return "You have nothing lol";
        
        string inventory = "";
        for (int i = 0; i < Items.ToArray().Length; i++)
        {
            Item item = Items.ToArray()[i];
            inventory += $"{i + 1}. {item.Name}";
            if (i != Items.ToArray().Length - 1) inventory += "\n";
        }

        return inventory;
    }
}