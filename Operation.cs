using System.Collections.Generic; 

public class Operation
{
    private InventoryItem item = new InventoryItem();

    public void Add(int amount)
    {
        item.amount += amount;
    }

    public void Substract(int amount)
    {
        item.amount -= amount;
    }

    public void SetName(string newName)
    {
        item.name = newName;
    }

    //ToDo: Figure out if the object being changed even exist in the first place
    public bool DoesObjectExist()
    {
        return true;
    }
}