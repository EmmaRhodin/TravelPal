using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Controls;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Page
    {
        public UserDetailsWindow()
        {
            InitializeComponent();
        }
        public class UserManager
        {
            public static List<IUser> Users { get; set; } = new()
            {
                new User("user", "password", "Sweden"),
                new Admin("admin", "password", "Sweden"),
            };
            public static IUser? CurrentlySignedInUser { get; set; }
            public static IUser? RegisterUser(string username, string password, string country)
            {
                if (ValidateUsername(username))
                {
                    User newUser = new(username, password, country);
                    Users.Add(newUser);

                    return newUser;
                }
                return null;
            }

            // + addUser(IUser): Bool
            // + removeUser(IUser): Void
            private static bool ValidateUsername(string username)
            {
                bool isValidated = true;
                foreach (var user in Users)
                {
                    if (user.Username == username)
                    {
                        isValidated = false;
                    }
                }
                return isValidated;
            }
            public static bool UserSignIn(string username, string password)
            {
                foreach (var user in Users)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        CurrentlySignedInUser = user;
                        return true;
                    }
                }
                return false;
            }
            public static void UserSignOut()
            {
                CurrentlySignedInUser = null;
            }
        }
        public class IUser
        {
            public required string Username { get; set; }
            public required string Password { get; set; }
            public required string Country { get; set; }

            [SetsRequiredMembers]
            public IUser(string username, string password, string country)
            {
                Username = username;
                Password = password;
                Country = country;
            }
        }
        public class User : IUser
        {
            // public static List<Travel> travel { get; set; } = new();



            [SetsRequiredMembers]
            public User(string username, string password, string country) : base(username, password, country)
            {
            }

        }
        public class Admin : IUser
        {
            [SetsRequiredMembers]
            public Admin(string username, string password, string country) : base(username, password, country)
            {
            }
        }
    }
}
