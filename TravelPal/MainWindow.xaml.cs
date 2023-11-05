using System.Windows;
using static TravelPal.UserDetailsWindow;

namespace TravelPal
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

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (txtbxUsername.Text.Length == 0)
            {
                txtErrormessage.Text = "Enter username!";
            }
            else if (txtbxPassword.Text.Length == 0)
            {
                txtErrormessage.Text = "Enter password!";
            }
            else
            {
                string username = txtbxUsername.Text;
                string password = txtbxPassword.Text;

                bool successfulLogIn = UserManager.UserSignIn(username, password);
                if (successfulLogIn == true)
                {
                    Window travelsWindow = new TravelsWindow();
                    travelsWindow.Show();
                    this.Close();
                }
                else
                {
                    txtErrormessage.Text = "Incorrect username or password";
                }
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Window registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }
    }
}
