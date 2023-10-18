using Prototype_Game_Interaction;
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
    /// Interaction logic for StartSpel.xaml
    /// </summary>
    public partial class StartSpel : Window
    {
        public StartSpel()
        {
            InitializeComponent();
        }
        private void SpelenClick(object sender, RoutedEventArgs e)
        {
            SharedData.CurrentScreen = "GameWindow";

            GameWindow gameWindow = new GameWindow();
            gameWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
        private void MainWindowClick(object sender, RoutedEventArgs e)
        {
            SharedData.CurrentScreen = "MainWindow";

            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
        private void InstellingenClick(object sender, RoutedEventArgs e)
        {
            Instellingen instellingen = new Instellingen();
            instellingen.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
    }
}
