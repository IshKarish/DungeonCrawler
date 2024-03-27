namespace DungeonCrawler;

public class Inventory
{
    public List<Item> Items { get; private set; }

    public Inventory()
    {
        Items = new List<Item>();
    }
    
    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    public void RemoveItem(string name)
    {
        foreach (Item i in Items.ToArray())
        {
            if (i.Name == name)
            {
                Items.Remove(i);
                return;
            }
        }
    }
    
    public void RemoveItem(Item item)
    {
        Items.Remove(item);
    }

    public bool HasItem(string name)
    {
        foreach (Item i in Items.ToArray())
        {
            if (i.Name == name) return true;
        }

        return false;
    }
}