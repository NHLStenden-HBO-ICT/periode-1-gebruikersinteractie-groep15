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
    /// Interaction logic for AfsluitMenu.xaml
    /// </summary>
    public partial class AfsluitMenu : Window
    {
        public AfsluitMenu()
        {
            InitializeComponent();
            this.KeyDown += Afsluiten_keyDown;
            this.KeyDown += MainWindow_keyDown;
        }

        private void AfsluitenClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NietafsluitenClick(object sender, RoutedEventArgs e)
        {
            SharedData.CurrentScreen = "MainWindow";

            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void Afsluiten_keyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Application.Current.Shutdown();
            }
        }

        private void MainWindow_keyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Hidden;
            }
        }
    }
}
