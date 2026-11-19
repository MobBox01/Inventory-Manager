using System;
using Microsoft.Data.Sqlite;

public class DataCommunicator
{
    private readonly string connectingString = "Data Source=Inventory.db";


    //Initialize database tables for the Users and the tables.
    public DataCommunicator()
    {
        using SqliteConnection connection = new SqliteConnection(connectingString);
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


    //create a entirely new item, tie it to user
    public void CreateItem()
    {

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