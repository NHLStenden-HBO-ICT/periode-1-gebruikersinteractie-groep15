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
using Prototype_Game_Interaction;

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
            SharedData.CurrentScreen = "MainWindow";
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            SharedData.CurrentScreen = "StartSpel";

            StartSpel startSpel = new StartSpel();
            startSpel.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
        private void ScoreBoardClick(object sender, RoutedEventArgs e)
        {
            SharedData.CurrentScreen = "ScoreBoard";

            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void InstellingenClick(object sender, RoutedEventArgs e)
        {
            SharedData.CurrentScreen = "Instellingen";

            Instellingen instellingen = new Instellingen();
            instellingen.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
            

        }
        private void HelpClick(object sender, RoutedEventArgs e) 
        {
            SharedData.CurrentScreen = "Help";

            Help help = new Help();
            help.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;

        }
        private void QuitButtonClick(object sender, RoutedEventArgs e)
        {
            SharedData.CurrentScreen = "AflsuitMenu";

            AfsluitMenu afsluitMenu = new AfsluitMenu();
            afsluitMenu.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
        
    }
}
