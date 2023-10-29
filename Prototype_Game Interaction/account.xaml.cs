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





        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string gebruikersnaam = gebruiker.Text;
            string email = mail.Text;
            string wachtwoord = ww.Text;
            string postcode = pc.Text;

            // zorgt ervoor dat geen gegevens missen

            if (string.IsNullOrEmpty(gebruikersnaam))
            {
                MessageBox.Show("Vull uw gebruikersnaam in");
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vull uw email in");
                return;
            }

            if (string.IsNullOrEmpty(wachtwoord))
            {
                MessageBox.Show("Vull uw wachtwoord in");
                return;
            }


            using (UserDataContext context = new UserDataContext())
            {
                // Maakt een nieuwe gebruiker
                User newUser = new User
                {
                    gebruikersnaam = gebruikersnaam,
                    email = email,
                    wachtwoord = wachtwoord,
                    postcode = postcode
                };

                // Voegt de gegevens in de databese
                context.Users.Add(newUser);
                context.SaveChanges(); // slaat de gegevens in de databease op
            }

            Inlog inlog = new Inlog();
            inlog.Visibility = Visibility.Visible;
            this.Close();
        }

    }
}
