public class InventoryItem
{
	//We will eventually focus on encapsulation
	public string name { get; set; }
	public int amount { get; set; }
	public int idKey { get; set; }
	public int userID { get; set; }

	public InventoryItem()
	{
		name = "TBd";
		amount = 0;
		idKey = 69;
		userID = 3;
	}
}


// +1, -1 buttons
//Set -> Name, Number