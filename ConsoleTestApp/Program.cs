using System.Data.SQLite;

namespace SQLiteTest
{
  class Program
  {
    public static void Main(string[] args)
    {
      System.Console.WriteLine("Starting SQLite Test Application\n\n");

      SQLiteConnection sqlite_connection;

      System.Console.WriteLine("\nConnecting to database");
      sqlite_connection = CreateConnection();

      System.Console.WriteLine("\nCreating tables");
      CreateTable(sqlite_connection);

      System.Console.WriteLine("\nInserting Data");
      InsertData(sqlite_connection);

      System.Console.WriteLine("\nQuering Database");
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
      catch (System.Exception except)
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
      string Createsql = "CREATE TABLE IF NOT EXISTS SampleTable (Col1 VARCHAR(20), Col2 INT)";
      string Createsql1 = "CREATE TABLE IF NOT EXISTS SampleTable1 (Col1 VARCHAR(20), Col2 INT)";

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
        System.Console.WriteLine(myreader);
      }

      connection.Close();
    }

  }
}