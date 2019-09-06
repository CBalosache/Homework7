using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQL
{
    public class Program
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static void Main(string[] args)
        {
            update u = new update();
            u.UpdateRecord();
        }
    }
    public class Game
    {
        string name = "";
        string genre = "";
        string type = "";
        string review = "";

        public string Name { get => name; set => name = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Type { get => type; set => type = value; }
        public string Review { get => review; set => review = value; }
    }
    class create
    {
        public void CreateTable()
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            string createTable = "Create Table Game(name varchar(10),game varchar(10),type_of_game varchar(10),review varchar(10))";
            try
            {
                SqlCommand CTable = new SqlCommand(createTable, conn);
                conn.Open();
                CTable.ExecuteReader();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Something happen to the server" + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
     }
    class read
    {
        public void ReadTable()
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            string ReadTable = "SELECT * FROM GAME";
            try
            {
                SqlCommand RTable = new SqlCommand(ReadTable, conn);
                conn.Open();
                RTable.ExecuteReader();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Something happen to the server" + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
    class update
    {
        public void UpdateRecord()
        {
            string newName = "Trump";
            SqlConnection conn = new SqlConnection(Program.connectionString);
            string UpdateRecord = "UPDATE Game SET name = '" + newName + "' WHERE Name = 'Pepe'";
            Console.WriteLine(UpdateRecord);
            Console.ReadLine();
            try
            {
                SqlCommand UTable = new SqlCommand(UpdateRecord, conn);
                conn.Open();
                UTable.ExecuteReader();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Something happen to the server" + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
    class delete
    {
        public void DeleteRecord()
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            string RemoveRecord = "DELETE FROM Game WHERE Name = 'Tetris';";
            try
            {
                SqlCommand UTable = new SqlCommand(RemoveRecord, conn);
                conn.Open();
                UTable.ExecuteReader();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Something happen to the server" + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
