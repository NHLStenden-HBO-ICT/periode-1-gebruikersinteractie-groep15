using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using Prototype_Game_Interaction;

namespace Prototype_Game_Interaction
{
    /// <summary>
    /// Interaction logic for Endgame.xaml
    /// </summary>
    public partial class Endgame : Window
    {
        public Endgame()
        {
            InitializeComponent();
            this.KeyDown += Button5_keyDown;
            this.KeyDown += Button4_keyDown;
            
        }

        private void MenuClick(object sender, RoutedEventArgs e)
        {
            // voor de knop om naar het begin menu te gaan
            SharedData.CurrentScreen = "MainWindow";

            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void GameClick(object sender, RoutedEventArgs e)
        {
            // voor de knop om terug te gaan naar het spel
            SharedData.CurrentScreen = "GameWindow";

            GameWindow gameWindow = new GameWindow();
            gameWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void Button5_keyDown(object sender, KeyEventArgs e)
        {
            // dit is als test om te kijken of de knop werkt
            if (e.Key == Key.Enter)
            {
                Scorespeler1.Text = "Score: 999999";
            }
        }

        private void Button4_keyDown(object sender, KeyEventArgs e)
        {
            // dit is als test om te kijken of de knop werkt
            if (e.Key == Key.Enter)
            {
                Scorespeler2.Text = "Score: 50";
            }
        }
        /* hiet moet not ergens een functie komen die de score van de speler ophaalt en in de text box zet en die van de speler vergelijkt met de tegenstander dus ook een af statement*/
    }
}
