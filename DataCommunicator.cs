using Microsoft.Data.Sqlite;
using System;
using static System.Net.Mime.MediaTypeNames;

public class DataCommunicator
{
    private readonly string connectingString = "Data Source=Inventory.db";


    //Initialize database tables for the Users and the tables.
    public DataCommunicator()
    {
        using var connection = new SqliteConnection(connectingString);
        connection.Open();

        string createTableSql = @"
        CREATE TABLE IF NOT EXISTS Users (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            Password TEXT NOT NULL
        );

        CREATE TABLE IF NOT EXISTS Inventory (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            UserId INTEGER NOT NULL,
            Name TEXT NOT NULL,
            Quantity INTEGER NOT NULL,
            FOREIGN KEY (UserId) REFERENCES Users(Id)
        );";

        using var command = new SqliteCommand(createTableSql, connection);

        command.ExecuteNonQuery();

        Console.WriteLine("Tables made!");
    }


    /**
     * Create a new item into the database. 
     */
    public void CreateItem(int userId,string name,int quantity)
    {
        using var connection = new SqliteConnection(connectingString);
        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText = @"INSERT INTO Inventory (UserId,Name,Quantity)
                VALUES ($UserId, $Name, $Quantity);";

        command.Parameters.AddWithValue("$UserId", userId);
        command.Parameters.AddWithValue("$Name", name);
        command.Parameters.AddWithValue("$Quantity",quantity);

        command.ExecuteNonQuery();
    }

    //This will create a user, debug only
    public void Temporary()
    {
        using var connection = new SqliteConnection(connectingString);
        connection.Open();
        using var command = connection.CreateCommand();

        command.CommandText = @"INSERT INTO Users (Name,Password)
                VALUES ($Name,$Password);";

        command.Parameters.AddWithValue("$Name", "Zay");
        command.Parameters.AddWithValue("$Password", "123");

        command.ExecuteNonQuery();
    }

    public List<InventoryItem> ReadInformation()
    {
        var items = new List<InventoryItem>();
        using var connection = new SqliteConnection(connectingString);
        connection.Open();
        using var command = connection.CreateCommand();

        command.CommandText = @"SELECT UserId, Id, Name, Quantity
                                FROM Inventory
                                WHERE UserId = $UserId;";
        command.Parameters.AddWithValue("$UserId", 1);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            items.Add(new InventoryItem()
            {
                userID = reader.GetInt32(0),
                id = reader.GetInt32(1),
                name = reader.GetString(2),
                amount = reader.GetInt32(3)
            });
        }

        return items;
    }
    //ID, what item, what to change name to 
    public void ChangeItemName()
    {

    }
    
    //ID, what item, how should you change it -1, +1, custom -/+
    public void ChangeQuantity()
    {

    }

    //USer ID, item ID
    public void DeleteItem()
    {

    }
}