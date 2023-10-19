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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prototype_Game_Interaction
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void Image_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            StartSpel startSpel = new StartSpel();
            startSpel.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void Image_MouseUp_2(object sender, MouseButtonEventArgs e)
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void Image_MouseUp_3(object sender, MouseButtonEventArgs e)
        {
            Instellingen instellingen = new Instellingen();
            instellingen.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void Image_MouseUp_4(object sender, MouseButtonEventArgs e)
        {
            Help help = new Help();
            help.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void Image_MouseUp_5(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
