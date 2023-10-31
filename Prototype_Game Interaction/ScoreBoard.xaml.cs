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
using Prototype_Game_Interaction;

namespace Prototype_Game_Interaction
{
    /// <summary>
    /// Interaction logic for ScoreBoard.xaml
    /// </summary>
    public partial class ScoreBoard : Window
    {
        public ScoreBoard()
        {
            InitializeComponent();
            this.KeyDown += MainWindow_keyDown; // voor de knop om terug te gaan naar het hoofdmenu
        }
        private void MainWindowClick(object sender, RoutedEventArgs e)
        {
            SharedData.CurrentScreen = "MainWindow";

            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void MainWindow_keyDown(object sender, KeyEventArgs e)
        {
            // when the Esc key is pressed the screen will go back to the main menu
            if (e.Key == Key.Escape)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Hidden;
            }
        }
    }
}
