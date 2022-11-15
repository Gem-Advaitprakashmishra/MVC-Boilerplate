using Assignment1.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            binddatagrid();
        }
        private string CnnStr = ("Data Source = 10.50.18.16; Initial Catalog = training_db; User ID = SVC_TRANING; Password = Gemini@123;");

        private void binddatagrid()
        {
            SqlConnection Con = new SqlConnection(CnnStr);

            Con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from UserDetail";
            cmd.Connection = Con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("UserDetail");
            da.Fill(dt);

            g1.ItemsSource = dt.DefaultView;


        }
        private void g1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginView sys = new LoginView();
            Close();
            
        }
    }
}
