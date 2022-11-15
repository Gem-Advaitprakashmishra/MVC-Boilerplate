using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Assignment1.View;

namespace Assignment1.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string UserName;
        public string username
        {
            get { return UserName; }
            set
            {
                UserName = value;
                NotifyPropertyChanged("username");
            }
        }

        private string Password;
        public string password
        {
            get { return Password; }
            set
            {
                Password = value;
                NotifyPropertyChanged("password");
            }
        }
        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }

        public ICommand cmdlogin { get; private set; }
        public bool CanExectute
        {
            get { return !string.IsNullOrEmpty(UserName) & !string.IsNullOrEmpty(Password); }
        }

        private string Connectionstring = ("Data Source = 10.50.18.16; Initial Catalog = training_db; User ID = SVC_TRANING; Password = Gemini@123; TrustServerCertificate=True");
        public LoginViewModel()
        {
            cmdlogin = new Command(Save, () => CanExectute);
        }

        private void Save()
        {

            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = " Select * from UserDetail where username = @UserName and password = @Password";
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Password", password); cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                MainWindow m = new MainWindow();
                m.Show();
                con.Close();
                username = "";
                password = "";
                LoginView login = new LoginView();
                login.Close();
            }
            else
            {
                ErrorMessage = "No account registerd with these details";
            }


        }
    }
}


