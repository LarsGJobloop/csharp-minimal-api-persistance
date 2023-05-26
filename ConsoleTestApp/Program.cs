using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTest
{
  class Program
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("Starting SQLite Test Application\n\n");

      SQLiteConnection sqlite_connection;

      Console.WriteLine("\nConnecting to database");
      sqlite_connection = CreateConnection();

      Console.WriteLine("\nCreating tables");
      // CreateTable(sqlite_connection);

      Console.WriteLine("\nInserting Data");
      InsertData(sqlite_connection);

      Console.WriteLine("\nQuering Database");
      ReadData(sqlite_connection);
    }

    static SQLiteConnection CreateConnection()
    {
      SQLiteConnection sql_connection;

      sql_connection = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");

      try
      {
        sql_connection.Open();
      }
      catch (Exception except)
      {
        // TODO: Decide what to do with error
      }

      return sql_connection;
    }

    static void CreateTable(SQLiteConnection connection)
    {
      SQLiteCommand sqlite_command;

      sqlite_command = connection.CreateCommand();

      // Create tables
      string Createsql = "CREATE TABLE SampleTable (Col1 VARCHAR(20), Col2 INT)";
      string Createsql1 = "CREATE TABLE SampleTable1 (Col1 VARCHAR(20), Col2 INT)";

      sqlite_command.CommandText = Createsql;
      sqlite_command.ExecuteNonQuery();
      sqlite_command.CommandText = Createsql1;
      sqlite_command.ExecuteNonQuery();
    }

    static void InsertData(SQLiteConnection connection)
    {
      SQLiteCommand sqlite_command;

      sqlite_command = connection.CreateCommand();

      sqlite_command.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES ('Test Text ', 1);";
      sqlite_command.ExecuteNonQuery();
      sqlite_command.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES ('Test1 Text1 ', 2);";
      sqlite_command.ExecuteNonQuery();
      sqlite_command.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES ('Test2 Text2 ', 3);";
      sqlite_command.ExecuteNonQuery();

      sqlite_command.CommandText = "INSERT INTO SampleTable1(Col1, Col2) VALUES ('Test3 Text3 ', 3);";
      sqlite_command.ExecuteNonQuery();
    }

    static void ReadData(SQLiteConnection connection)
    {
      SQLiteDataReader sqlite_datareader;
      SQLiteCommand sqlite_command;

      sqlite_command = connection.CreateCommand();
      sqlite_command.CommandText = "SELECT * FROM SampleTable";

      sqlite_datareader = sqlite_command.ExecuteReader();
      while (sqlite_datareader.Read())
      {
        string myreader = sqlite_datareader.GetString(0);
        Console.WriteLine(myreader);
      }

      connection.Close();
    }

  }
}