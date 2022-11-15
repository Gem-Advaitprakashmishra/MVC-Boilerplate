using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Assignment1.ViewModel
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
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
        private string FirstName;
        public string firstname
        {
            get { return FirstName; }
            set
            {
                FirstName = value;
                NotifyPropertyChanged("firstname");
            }
        }
        private string LastName;
        public string lastname
        {
            get { return LastName; }
            set
            {
                LastName = value;
                NotifyPropertyChanged("lastname");
            }
        }
        private string Gender;
        public string gender
        {
            get { return Gender; }
            set
            {
                Gender = value;
                NotifyPropertyChanged("gender");
            }
        }
        private string EmailAddress;
        public string emailaddress
        {
            get { return EmailAddress; }
            set
            {
                EmailAddress = value;
                NotifyPropertyChanged("emailaddress");
            }
        }
        private string Dob;
        public string dob
        {
            get { return Dob; }
            set
            {
                Dob = value;
                NotifyPropertyChanged("dob");
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
        public ICommand cmdSave { get; private set; }

        public bool CanExectute
        {

            get
            {
                return true;//!string.IsNullOrEmpty(username) & !string.IsNullOrEmpty(firstname) & !string.IsNullOrEmpty(lastname) & !string.IsNullOrEmpty(gender) & !string.IsNullOrEmpty(emailaddress) & !string.IsNullOrEmpty(dob) & !string.IsNullOrEmpty(password);
            }

        }
        //   private string Connectionstring = Properties.Settings.Default.Setting;
        private string Connectionstring = ("Data Source = 10.50.18.16; Initial Catalog = training_db; User ID = SVC_TRANING; Password = Gemini@123; TrustServerCertificate=True");
        public RegistrationViewModel()
        {
            cmdSave = new Command(Register, () => CanExectute);
        }

        private void Register()
        {
            SqlConnection con = new SqlConnection(Connectionstring);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Insert UserDetail(UserName,FirstName,LastName,Gender,Emailaddress,Dob,Password) Values(@UserName,@FirstName,@LastName,@gender,@emailaddress,@dob,@password) ";
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@FirstName", firstname);
            cmd.Parameters.AddWithValue("@LastName", lastname);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@EmailAddress", emailaddress);
            cmd.Parameters.AddWithValue("@Dob", dob);
            cmd.Parameters.AddWithValue("@Password", password);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ErrorMessage = ex.Message;

            }
            finally
            {

            }
            // ErrorMessage =  "User Registered Successfully ;)";

        }
    }
}
