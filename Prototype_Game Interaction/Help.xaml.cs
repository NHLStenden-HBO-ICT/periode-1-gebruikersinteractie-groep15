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
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();
            this.KeyDown += MainWindow_KeyDown; // maakt onderdeel uit van de key press om terug te gaan naar het begin menu. 
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                // when the Esc key is pressed the screen will go to the BeginMenu
                // voor de knop om naar het begin menu te gaan
                SharedData.CurrentScreen = "MainWindow";

                MainWindow mainWindow = new MainWindow();
                mainWindow.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Hidden;
            }
        }
    }
}
