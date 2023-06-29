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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WpfZoo_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection SqlConnection;
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["WpfZoo_Manager.Properties.Settings.YingweiDBConnectionString"].ConnectionString;
            SqlConnection = new SqlConnection(connectionString);
            showZoos();
            //ShowAssociatedAnimalsC();
            AnimalList();
            

        }

        private void showZoos()
        {
            try
            {
                string query = "select * from Zoo";
            //the sqlDataAdapter cna be imaged like an Interface to make tables usable by c# objects
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, SqlConnection);
                using (sqlDataAdapter)
                {
                    DataTable zooTable = new DataTable();
                    sqlDataAdapter.Fill(zooTable);

                    //which information of the Table in DataTable should be shown in out ListBox
                    ListZoos.DisplayMemberPath = "Location";
                    //which value should be delivered, when an item from our listBox is slectec.
                    ListZoos.SelectedValuePath = "Id";
                    //the reference to the data the listbox should populate.
                    ListZoos.ItemsSource = zooTable.DefaultView;
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ShowAssociatedAnimal()
        {
            try { 
            string query = "select * from Animal a inner join AnimalZoo az " +
                "on a.Id=az.AnimalID where az.ZooID=@ZooID";

            SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);
            //the sqlDataAdapter cna be imaged like an Interface to make tables usable by c# objects
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            
           
                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@ZooID", ListZoos.SelectedValue);
                    DataTable AnimalTable = new DataTable();
                    sqlDataAdapter.Fill(AnimalTable);

                    //which information of the Table in DataTable should be shown in out ListBox
                    ShowAssociatedAnimals.DisplayMemberPath = "Name";
                    //which value should be delivered, when an item from our listBox is slectec.
                    ShowAssociatedAnimals.SelectedValuePath = "Id";
                    //the reference to the data the listbox should populate.
                    ShowAssociatedAnimals.ItemsSource = AnimalTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        private void AnimalList()
        {
            try
            {
                string query = "select * from Animal";

                SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);
                //the sqlDataAdapter cna be imaged like an Interface to make tables usable by c# objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);


                using (sqlDataAdapter)
                {
                   // sqlCommand.Parameters.AddWithValue("@ZooID", ListZoos.SelectedValue);
                    DataTable Animal_list_Table = new DataTable();
                    sqlDataAdapter.Fill(Animal_list_Table);

                    //which information of the Table in DataTable should be shown in out ListBox
                    Animal_List.DisplayMemberPath = "Name";
                    //which value should be delivered, when an item from our listBox is slectec.
                    Animal_List.SelectedValuePath = "Id";
                    //the reference to the data the listbox should populate.
                    Animal_List.ItemsSource = Animal_list_Table.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ListZoos_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("ListZoos was clicked");
            ShowAssociatedAnimal();

        }

        private void Delete_Zoo(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                string query = "delete from Zoo where id=@ZooID";
                SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);
                SqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooID", ListZoos.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SqlConnection.Close();
                showZoos();
            }
        }

        private void Add_Zoos(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                string query = " insert into Zoo values (@Location) ";
                SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);
                SqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Locationa", Textbox_Buttom.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SqlConnection.Close();
                showZoos();
            }

        }
      
    }
}
