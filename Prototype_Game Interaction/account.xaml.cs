using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace Prototype_Game_Interaction
{
    /// <summary>
    /// Interaction logic for account.xaml
    /// </summary>
    public partial class account : Window
    {
        
        public account()
        {
            InitializeComponent();
        }

    

        private void inlog()
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var gebruikersnaam = gebruiker.Text;
            var email = mail.Text;
            var wachtwoord = ww.Text;
            var postcode = pc.Text;

            using (UserDataContext context = new UserDataContext())
            {
                // Create a new user object and set its properties
                User newUser = new User
                {
                    gebruikersnaam = gebruikersnaam,
                    email = email,
                    wachtwoord = wachtwoord,
                    postcode = postcode
                };

                // Add the user object to the database
                context.Users.Add(newUser);
                context.SaveChanges(); // Save changes to the database
            }

            inlog();
        }
    }
}
