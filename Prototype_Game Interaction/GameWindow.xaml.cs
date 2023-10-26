using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Prototype_Game_Interaction;


namespace Prototype_Game_Interaction
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public bool lift1, lift2 = true;
        private DispatcherTimer GameTimer = new DispatcherTimer();
        private ImageBrush player1Brush = new ImageBrush();
        private ImageBrush player2Brush = new ImageBrush();

        private Key[] keysPlayer1 = { Key.W, Key.S, Key.D, Key.A };
        private Key[] keysPlayer2 = { Key.Up, Key.Down, Key.Right, Key.Left };
        public Key lift1Key, lift2Key;


        public GameWindow()
        {
            InitializeComponent();
            this.KeyDown += PauzeMenu_keyDown; // voor de knop om naar het pauze menu te gaan
            this.KeyDown += Button1_keyDown;


          

            this.KeyDown += new KeyEventHandler(Player1Controls);
            this.KeyUp += new KeyEventHandler(Player1Controls);

            this.KeyDown += new KeyEventHandler(Player2Controls);
            this.KeyUp += new KeyEventHandler(Player2Controls);

            GameTimer.Interval = TimeSpan.FromMilliseconds(20);
            GameTimer.Tick += GameEngine;
            GameTimer.Start();
        }




        private void GameEngine(object? sender, EventArgs e)
        {
            // Controls
            Random random = new Random();
            lift1Key = keysPlayer1[random.Next(keysPlayer1.Length)];
            lift2Key = keysPlayer2[random.Next(keysPlayer2.Length)];
        }

       


        private void Player1Controls(object sender, KeyEventArgs e)
        {

            // Controls Player 1
            if (e.Key == Key.W)
                lift1 = true;

            if (e.Key == Key.S)
                lift1 = true;

            if (e.Key == Key.D)
                lift1 = true;

            if (e.Key == Key.A)
                lift1 = true;

        }


        private void Player2Controls(object sender, KeyEventArgs e)
        {

            // Controls Player 2

            if (e.Key == Key.Up)
                lift2 = true;

            if (e.Key == Key.Down)
                lift2 = true;

            if (e.Key == Key.Right)
                lift2 = true;

            if (e.Key == Key.Left)
                lift2 = true;

        }



        private void PauzeMenu_keyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                // when the Esc key is pressed the screen will go to the PauzeMenu
                // voor de knop om naar het pauze menu te gaan
                SharedData.CurrentScreen = "PauzeMenu";

                PauzeMenu pauzeMenu = new PauzeMenu();
                pauzeMenu.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Hidden;
            }
        }

        private void Button1_keyDown(object sender, KeyEventArgs e)
        {
            // dit is als test om te kijken of de knop werkt
            if (e.Key == Key.Enter)
            {
                knop.Text = "Nee mag niet!!";
            }
        }
    }
}
