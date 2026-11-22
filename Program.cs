public class Program
{
    //Debug!
    public static void Main(string[] args)
    {
        var communicator = new DataCommunicator();
        var tempList = communicator.ReadInformation();

        foreach(var item in tempList)
        {
            Console.WriteLine($@"User ID:{item.userID}
                    ID: {item.Id}
                    Name: {item.name}
                    Quantity: {item.quantity}");
        }
    }
}
/**var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//Scenario 1: + button -> adds 1 
//app.PostMap 
//Scenario 2: - button -> removes 2 
//Scenario 3: Set field -> sets the value 
//Scenario 4: Add total -> adds a specific amount
//Scneario 5: Remove total -> removes a specific amount

//Keep track of if the object even exist for each operation

app.Run();
**/