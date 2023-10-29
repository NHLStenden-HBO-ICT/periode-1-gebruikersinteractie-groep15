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
    public partial class EndGame : Window
    {
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }


        public EndGame()
        {
            InitializeComponent();

        }

        public void SetPlayerScores(int player1Score, int player2Score)
        {
            Player1Score = player1Score;
            Player2Score = player2Score;
            // Update de score-weergave in de GUI met deze waarden
            player1ScoreText.Text = $"Score: {Player1Score}";
            player2ScoreText.Text = $"Score: {Player2Score}";
        }

        public void SetWinner()
        {
            if (Player1Score > Player2Score)
            {
                winnaar.Text = "De winnaar is: Speler 1!";
            }
            else if (Player2Score > Player1Score)
            {
                winnaar.Text = "De winnaar is: Speler 2!";
            }
            else
            {
                winnaar.Text = "Het is een gelijkspel!";
            }
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

       
    }
}