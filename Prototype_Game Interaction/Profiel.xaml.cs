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

namespace Prototype_Game_Interaction
{
    /// <summary>
    /// Interaction logic for Profiel.xaml
    /// </summary>
    public partial class Profiel : Window
    {
        public Profiel()
        {
            InitializeComponent();
            Gebruikersnaam.Text = change.Text;
            wacht.Text = change.Text2;
            mail.Text = change.Text3;
            Postcode.Text = change.Text4;
        }



        private void ZekerheidClick(object sender, RoutedEventArgs e)
        {
            // voor de knop om naar het begin menu te gaan maar je moet eerst nog dat bevestingen in een ander menu
            SharedData.CurrentScreen = "ConformatieMenu";

            ZekerheidMenu zekerheidMenu = new ZekerheidMenu();
            zekerheidMenu.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void Gebruikersnaam_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void mail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
