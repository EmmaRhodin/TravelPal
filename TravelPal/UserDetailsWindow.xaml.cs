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
            // + users: List<IUser>
            public static List<IUser> Users { get; set; } = new()
            {
                new User("testing", "password", "Sweden"),
                new Admin("placeholder", "password", "Sweden"),
            };
            // + signedInUser: IUser
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
            // + updateUserName(IUser, string): Bool
            // - validateUsername(username): Bool
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
            // + signInUser(username, password): Bool
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
            // + username: string
            public required string Username { get; set; }
            // + password: string
            public required string Password { get; set; }
            // + location: Country
            public required string Country { get; set; }

            // + IUser(username, password, location)
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
