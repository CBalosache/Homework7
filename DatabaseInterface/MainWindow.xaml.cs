using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using SQL;

namespace DatabaseInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Game game = new Game();
            game.Name = NameBox.Text;
            game.Genre = GenreBox.Text;
            game.Type = TypeBox.Text;
            game.Review = ReviewBox.Text;
            SqlConnection conn = new SqlConnection(connectionString);
            string InsertString = String.Format("Insert into game (name,game,type_of_game,review) Values('{0}','{1}','{2}','{3}')", game.Name, game.Genre, game.Type, game.Review);
            try
            {
                SqlCommand CTable = new SqlCommand(InsertString, conn);
                conn.Open();
                CTable.ExecuteReader();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Something happen to the server" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            if((game.Name == "")||(game.Genre == "")||(game.Type == "")||(game.Review == ""))
            {
                string WarningMessage = "You cannot leave empty fields";
                string WarningTitle = "Warning";
                MessageBox.Show(WarningMessage, WarningTitle);
            }
            else
            {
                string message = "Record Added to the data base.";
                string title = "Close Window";
                MessageBox.Show(message, title);
            }
        }
    }
}
