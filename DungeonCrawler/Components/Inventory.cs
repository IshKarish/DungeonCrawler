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
        string inventory = "";
        for (int i = 0; i < Items.ToArray().Length; i++)
        {
            Item item = Items.ToArray()[i];

            int itemCount = 1;
            for (int j = i + 1; j < Items.ToArray().Length; j++)
            {
                Item jItem = Items.ToArray()[j];
                if (jItem.Name == item.Name) itemCount++;
            }
            
            
            inventory += item.Name;
            if (i != Items.ToArray().Length - 1) inventory += ", ";
        }

        return inventory;
    }
}