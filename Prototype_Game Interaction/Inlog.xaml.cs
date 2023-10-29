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
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace Prototype_Game_Interaction
{
    /// <summary>
    /// Interaction logic for Inlog.xaml
    /// </summary>
    public partial class Inlog : Window
    {
        public Inlog()
        {
            InitializeComponent();
        }



        private void inlog()
        {
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var email = mail.Text;
            var wachtwoord = ww.Password;

            using (UserDataContext context = new UserDataContext())
            {
                bool gebruikergevonden = context.Users.Any(user => user.email == email && user.wachtwoord == wachtwoord);

                if (gebruikergevonden)
                {
                    inlog();
                    Close();
                }

                else
                {
                    MessageBox.Show("user not found");
                }
            }
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            account account = new account();
            account.Visibility = Visibility.Visible;
            this.Close();
        }
    }
    
}
