using System.Collections.Generic; 

//General manager 
//Has access to user operations and item operations 
//Eventually will seperate into UserOperator and ItemOperator classes

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


    //Obtain 25 items for the requested page (will adjust/revamp later this is place holder code)
    public List<InventoryItem> GetPage(int currentPageNumber)
    {
        var list = new List<InventoryItem>();

        //Start off from last page, (1-1 * 25 =0, 2-1 * 25 = 25)...; finish off or break from the loop later
        for (int i = (currentPageNumber - 1) * 25; i < 25 * currentPageNumber; i++)
        {
            //Case where it stops!
            //Place holder, ignore i ==0
            if (i == 0)
            {
                break;
            }
            else
            {
                list.Add(new InventoryItem());//continue adding to list
            }
        }
        return list;
    }
}