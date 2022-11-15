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
using System.Windows.Shapes;

namespace Assignment1.View
{
    /// <summary>
    /// Interaction logic for RegistrationViews.xaml
    /// </summary>
    public partial class RegistrationViews : Window
    {
        public RegistrationViews()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text != "" & firstname.Text != "" & lastname.Text != "" & gender.Text != "" & emailaddress.Text != "" & dob.Text != "" & password.Text != "")
            {
                MessageBox.Show("User Registerd Successfully");
            }
            else
            {
                MessageBox.Show("Please fill all details");
            }

        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            username.Text = firstname.Text = lastname.Text = gender.Text = emailaddress.Text = dob.Text = password.Text = cpass.Text = "";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginView login = new LoginView();
            this.Close();
            login.Show();

        }
    }
}
