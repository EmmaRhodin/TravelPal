using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

            foreach (Countries.EuropeanCountry country in (Countries.EuropeanCountry[])Enum.GetValues(typeof(Countries.EuropeanCountry)))
            {
                cbxChooseCountry.Items.Add(country);
            }
            foreach (Countries.Country country in (Countries.Country[])Enum.GetValues(typeof(Countries.Country)))
            {
                cbxChooseCountry.Items.Add(country);
            }
        }

        public void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            bool getUsername = false;
            bool getCountry = false;
            bool getPassword = false;
            bool validatePassword = false;

            if (txtbxCreateUser.Text.Length == 0)
            {
                txtCreateUserError.Text = "Input username!";
                getUsername = false;
            }
            else if (txtbxCreateUser.Text.Length < 6 || txtbxCreateUser.Text.Length > 20)
            {
                txtCreateUserError.Text = "Username has to be between 6 and 20 characters!";
                getUsername = false;
            }
            else if (!Regex.IsMatch(txtbxCreateUser.Text, @"^[a-zA-Z0-9]+$"))
            {
                txtCreateUserError.Text = "Username may only contain letters and numbers!";
                getUsername = false;
            }
            else
            {
                string checkUser = txtbxCreateUser.Text;
                foreach (var user in UserDetailsWindow.UserManager.Users)
                {
                    if (user.Username == checkUser)
                    {
                        txtCreateUserError.Text = "This username already exists!";
                        getUsername = false;
                    }
                    else
                    {
                        getUsername = true;
                        txtCreateUserError.Text = "";
                    }
                }
            }

            if (cbxChooseCountry.SelectedIndex < 0)
            {
                cbxChooseCountryError.Text = "Must select a country of origin!";
                getCountry = false;
            }
            else
            {
                getCountry = true;
                cbxChooseCountryError.Text = "";
            }

            if (txtbxCreatePassword.Text.Length == 0)
            {
                txtCreatePasswordError.Text = "Input password!";
                getPassword = false;
            }
            else if (txtbxCreateUser.Text.Length < 6 || txtbxCreateUser.Text.Length > 20)
            {
                txtCreatePasswordError.Text = "Password has to be between 6 and 20 characters!";
                getPassword = false;
            }
            else if (!Regex.IsMatch(txtbxCreateUser.Text, @"^[a-zA-Z0-9]+$"))
            {
                txtCreatePasswordError.Text = "Password may only contain letters and numbers!";
                getPassword = false;
            }
            else
            {
                getPassword = true;
                txtCreatePasswordError.Text = "";
            }

            if (txtbxVerifyPassword.Text != txtbxCreatePassword.Text)
            {
                txtVerifyPasswordError.Text = "Passwords do not match!";
                validatePassword = false;
            }
            else if (txtbxVerifyPassword.Text == txtbxCreatePassword.Text)
            {
                validatePassword = true;
                txtVerifyPasswordError.Text = "";
            }

            if (getUsername == true && getCountry == true && getPassword == true && validatePassword == true)
            {
                string username = txtbxCreateUser.Text;
                string country = cbxChooseCountry.Text;
                string password = txtbxCreatePassword.Text;

                UserDetailsWindow.User newUser = new(username, country, password);
                MainWindow mainWindow = new();
                mainWindow.Show();
                this.Close();
            }

        }
    }
}
