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
            /*public static IUser? RegisterUser(string username, string password) { }*/


            // + addUser(IUser): Bool
            // + removeUser(IUser): Void
            // + updateUserName(IUser, string): Bool
            // - validateUsername(username): Bool
            // + signInUser(username, password): Bool
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
