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
    /// Interaction logic for PauzeMenu.xaml
    /// </summary>
    public partial class PauzeMenu : Window
    {
        public PauzeMenu()
        {
            InitializeComponent();
            this.KeyDown += GameWindow_keyDown;
            this.KeyDown += ZekerheidMenu_keyDown;
        }

        private void ZekerheidClick (object sender, RoutedEventArgs e)
        {
            // voor de knop om naar het begin menu te gaan maar je moet eerst nog dat bevestingen in een ander menu
            SharedData.CurrentScreen = "ConformatieMenu";

            ZekerheidMenu zekerheidMenu = new ZekerheidMenu();
            zekerheidMenu.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void GameClick(object sender, RoutedEventArgs e) 
        {
            // voor de knop om terug te gaan naar het spel
            SharedData.CurrentScreen = "GameWindow";

            GameWindow gameWindow = new GameWindow();
            gameWindow.Visibility = Visibility.Visible;
            this.Visibility= Visibility.Hidden;
        }
        
        private void GameWindow_keyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                // when the Esc key is pressed the screen will go back to the game
                // voor de knop om verder te gaan met het spel.
                SharedData.CurrentScreen = "GameWindow";

                GameWindow gameWindow = new GameWindow();
                gameWindow.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Hidden;
            }
        }

        private void ZekerheidMenu_keyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // when the Enter key is pressed you wil go to the conformation menu
                // voor de knop om verder naar het conformatie scherm te gaan.
                SharedData.CurrentScreen = "ZekerheidMenu";

                ZekerheidMenu zekerheidMenu = new ZekerheidMenu();
                zekerheidMenu.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Hidden;
            }
        }

        private void EindClick(object sender, RoutedEventArgs e)
        {
            // voor de knop om naar het eind scherm te gaan
            SharedData.CurrentScreen = "Endgame";

            Endgame endgame = new Endgame();
            endgame.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
    }
}
