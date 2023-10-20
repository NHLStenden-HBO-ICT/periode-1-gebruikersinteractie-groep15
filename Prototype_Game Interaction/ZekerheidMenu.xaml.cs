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
    /// Interaction logic for ZekerheidMenu.xaml
    /// </summary>
    public partial class ZekerheidMenu : Window
    {
        public ZekerheidMenu()
        {
            InitializeComponent();
        }
        //Het terug gaan naar het begin menu
        private void JaClick(object sender, RoutedEventArgs e)
        {
            SharedData.CurrentScreen = "MainWindow";

            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
        // Het terug gaan naar Pauze menu
        private void NeeClick(object sender, RoutedEventArgs e)
        {
            SharedData.CurrentScreen = "PauzeMenu";

            PauzeMenu pauzeMenu = new PauzeMenu();
            pauzeMenu.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
    }
}
