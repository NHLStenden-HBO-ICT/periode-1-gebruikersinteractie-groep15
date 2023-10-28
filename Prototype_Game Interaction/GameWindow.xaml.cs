using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Prototype_Game_Interaction;
using static System.Net.Mime.MediaTypeNames;


namespace Prototype_Game_Interaction
{
    public partial class GameWindow : Window
    {
        public static GameWindow CurrentGameWindow { get; private set; }
        private bool isGameWindowVisible = true;
        private bool isPaused = false;
        private PauzeMenu pauzeMenu;

        private int frameIndex = 0;
        private int frameWidth = 512;
        private int frameHeight = 512;
        private int totalFrames = 22;
        private DispatcherTimer animationTimer;
        BitmapImage spriteSheet1 = new BitmapImage(new Uri("Assets/player1curlSheet.png", UriKind.Relative));
        BitmapImage spriteSheet2 = new BitmapImage(new Uri("Assets/player2curlSheet.png", UriKind.Relative));

        private Random random = new Random();
        private Key[] possibleKeysPlayer1 = { Key.W, Key.A, Key.S, Key.D };
        private Key[] possibleKeysPlayer2 = { Key.Up, Key.Down, Key.Left, Key.Right };

        private Key previousKeyPlayer1 = Key.None;
        private Key previousKeyPlayer2 = Key.None;

        private int player1Score = 0;
        private int player2Score = 0;

        private Key keyToPressPlayer1;
        private Key keyToPressPlayer2;

        private bool player1KeyProcessed = false;
        private bool player2KeyProcessed = false;

        // Game timer van 1 minuut
        private int remainingTime = 60; // 60 seconden, oftewel 1 minuut
        private DispatcherTimer gameTimer;

        // 3 seconden countdown voordat de game begint
        private int countdownTime = 3; 
        private DispatcherTimer countdownStartTimer;

        //Methode om de pijltjestoetsen te laten zien in het scherm ipv. Up, Down, Left, Right. Had vast mooier gekund, maar idk.
        private string GetKeyText(Key key)
        {
            switch (key)
            {
                case Key.Up:
                    return "↑"; // Pijltjestoets omhoog
                case Key.Left:
                    return "←"; // Pijltjestoets naar links
                case Key.Down:
                    return "↓"; // Pijltjestoets naar beneden
                case Key.Right:
                    return "→"; // Pijltjestoets naar rechts
                default:
                    return key.ToString();
            }
        }



        public GameWindow()
        {
            InitializeComponent();
            this.KeyDown += GameWindow_KeyDown;
            CurrentGameWindow = this;

            // animatie timer
            animationTimer = new DispatcherTimer();
            animationTimer.Interval = TimeSpan.FromMilliseconds(50);
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();

            // Game timer van 1 minuut
            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromSeconds(1); // Elke 1 seconde
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            // Afteltimer voor het starten van de game
            countdownStartTimer = new DispatcherTimer();
            countdownStartTimer.Interval = TimeSpan.FromSeconds(1);
            countdownStartTimer.Tick += CountdownStartTimer_Tick;
            countdownStartTimer.Start();

            // Maak de overlay-rechthoek zichtbaar en verberg de game-elementen
            countdownOverlay.Visibility = Visibility.Visible;

            // Pauzeer de animatie- en gametimer
            animationTimer.Stop();
            gameTimer.Stop();

            // Initialiseer het PauzeMenu en stel de zichtbaarheid in op Hidden
            pauzeMenu = new PauzeMenu();
            pauzeMenu.Visibility = Visibility.Hidden;

            GenerateKeysForNextRound();

            PauseGame();

            // Stel de initial visibility in
            isGameWindowVisible = true;
        }
        private void PauseGame()
        {
            isPaused = true;
            animationTimer.Stop();
            gameTimer.Stop();

            

            // Verberg de GameWindow wanneer het spel wordt gepauzeerd
            isGameWindowVisible = this.Visibility == Visibility.Visible;
            this.Visibility = Visibility.Hidden;

            // Toon het PauzeMenu wanneer het spel wordt gepauzeerd
            pauzeMenu.Visibility = Visibility.Visible;
        }

        public void ResumeGame()
        {
            isPaused = false;
            animationTimer.Start();
            gameTimer.Start();

            // Herstel de zichtbaarheid van de GameWindow wanneer het spel wordt hervat
            this.Visibility = isGameWindowVisible ? Visibility.Visible : Visibility.Hidden;

            // Verberg het PauzeMenu wanneer het spel wordt hervat
            pauzeMenu.Visibility = Visibility.Hidden;
        }

        // Countdown timer van 3 seconden voordat het spel begint.
        private void CountdownStartTimer_Tick(object sender, EventArgs e)
        {
            countdownTime--;

            if (countdownTime == 0)
            {
                // De countdown is afgelopen, stop de timer en start de game.
                countdownStartTimer.Stop();
                countDown.Visibility = Visibility.Hidden;

                // Maak de overlay-rectangle onzichtbaar en start de animatie- en gametimer opnieuw.
                countdownOverlay.Visibility = Visibility.Hidden;

                // Start de animatie- en gametimer opnieuw.
                animationTimer.Start();
                gameTimer.Start();
            }
            else
            {
                // Update de tekst op je scherm om de resterende tijd weer te geven.
                countDown.Text = $"{countdownTime}";
            }
        }


        // de 1 minuut gametimer. als deze is afgelopen dan eindigd het spel.
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            remainingTime--;

            if (remainingTime == 0)
            {
                // De tijd is verstreken, stop de timer en eindig het spel
                gameTimer.Stop();
                timeTextBlock.Text = "Tijd: 0";

                EndGame endGameScreen = new EndGame();

                // Onderstaande zorgt ervoor dat de winnaar en de gescoorde punten meegenomen worden naar het EndGame scherm.
                endGameScreen.SetPlayerScores(player1Score, player2Score);
                endGameScreen.SetWinner();

                endGameScreen.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Hidden;
                // hier nog code toevoegen wat je naar het einde spel scherm brengt en de resultaten laat zien.
            }
            else
            {
                // Werk de resterende tijd weer
                timeTextBlock.Text = $"Tijd: {remainingTime}";
            }
        }


        // Genereren van een random key voor speler 1 en speler 2 per animatie ronde
        private void GenerateKeysForNextRound()
        {
            Key newKeyPlayer1, newKeyPlayer2;

            do // zorgt ervoor dat speler 1 niet 2 animatierondes achter elkaar dezelfde knop krijgt te zien.
            {
                newKeyPlayer1 = possibleKeysPlayer1[random.Next(0, possibleKeysPlayer1.Length)];
            }
            while (newKeyPlayer1 == previousKeyPlayer1); // Blijf toetsen genereren totdat er een nieuwe is.

            do // zorgt ervoor dat speler 2 niet 2 animatierondes achter elkaar dezelfde knop krijgt te zien.
            {
                newKeyPlayer2 = possibleKeysPlayer2[random.Next(0, possibleKeysPlayer2.Length)];
            }
            while (newKeyPlayer2 == previousKeyPlayer2); // Blijf toetsen genereren totdat er een nieuwe is.


            keyToPressPlayer1 = newKeyPlayer1;
            keyToPressPlayer2 = newKeyPlayer2;

            previousKeyPlayer1 = newKeyPlayer1;
            previousKeyPlayer2 = newKeyPlayer2;

            //Geeft de toets in XAML, boven de spelers, aan welk ingedrukt moet worden om punten te verdienen.
            player1KeyInput.Text = keyToPressPlayer1.ToString();
            player2KeyInput.Text = GetKeyText(keyToPressPlayer2);

            // Reset de booleans die bijhouden of de toetsen zijn verwerkt
            player1KeyProcessed = false;
            player2KeyProcessed = false;
        }


        // De timer voor de animatie
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            frameIndex++;

            if (frameIndex > totalFrames)
            {
                frameIndex = 1;
                GenerateKeysForNextRound();
            }

            int x = (frameIndex - 1) * frameWidth;
            int y = 0;

            CroppedBitmap frame1 = new CroppedBitmap(spriteSheet1, new Int32Rect(x, y, frameWidth, frameHeight));
            CroppedBitmap frame2 = new CroppedBitmap(spriteSheet2, new Int32Rect(x, y, frameWidth, frameHeight));

            Player1curl.Source = frame1;
            Player2curl.Source = frame2;

            // Controleer of we ons binnen frame 9 en 15 bevinden
            if (frameIndex >= 9 && frameIndex <= 15)
            {
                // Schakel het drop shadow effect in
                Player1curl.Effect = new DropShadowEffect
                {
                    Color = Colors.Yellow,
                    Direction = 0,
                    BlurRadius = 50,
                    Opacity = 1.0
                };
                Player2curl.Effect = new DropShadowEffect
                {
                    Color = Colors.Red,
                    Direction = 0,
                    BlurRadius = 50,
                    Opacity = 1.0
                };
            }
            else
            {
                // Schakel het drop shadow effect uit (door deze op null te zetten)
                Player1curl.Effect = null;
                Player2curl.Effect = null;
            }
        }


        // dit controleert de keys van speler 1
        private bool IsPlayer1Key(Key key)
        {
            return key == Key.W || key == Key.A || key == Key.S || key == Key.D;
        }



        // dit controleert de keys van speler 2
        private bool IsPlayer2Key(Key key)
        {
            return key == Key.Up || key == Key.Down || key == Key.Left || key == Key.Right;
        }


        // Hier alle key aanslagen
        private void GameWindow_KeyDown(object sender, KeyEventArgs e)

        {
            // De escape knop brengt je naar het pauzemenu, en pauzeert dan dus ook de game.
            if (e.Key == Key.Escape)
            {
                if (isPaused)
                {
                    // Hervat het spel
                    ResumeGame();
                }
                else
                {
                    // Pauzeer het spel
                    PauseGame();
                }
                return;
            }

            // Player 1 control check. Checkt ook of er die animatieronde al een toets is aangeslagen.
            // Dit betekend: dezelfde animatieronde kun je maar 1 toetsaanslag doen, en die registreert min of plus punten.
            // je kunt geen twee aanslagen doen.
            if (frameIndex >= 9 && frameIndex <= 15)
            {
                if (keyToPressPlayer1 == Key.W && e.Key == Key.W)
                {
                    if (!player1KeyProcessed)
                    {
                        HandleCorrectKey(Player.Player1);
                        player1KeyProcessed = true;
                    }
                    return;
                }
                else if (keyToPressPlayer1 == Key.A && e.Key == Key.A)
                {
                    if (!player1KeyProcessed)
                    {
                        HandleCorrectKey(Player.Player1);
                        player1KeyProcessed = true;
                    }
                    return;
                }
                else if (keyToPressPlayer1 == Key.S && e.Key == Key.S)
                {
                    if (!player1KeyProcessed)
                    {
                        HandleCorrectKey(Player.Player1);
                        player1KeyProcessed = true;
                    }
                    return;
                }
                else if (keyToPressPlayer1 == Key.D && e.Key == Key.D)
                {
                    if (!player1KeyProcessed)
                    {
                        HandleCorrectKey(Player.Player1);
                        player1KeyProcessed = true;
                    }
                    return;
                }
                else if (keyToPressPlayer1 == Key.W && (e.Key == Key.A || e.Key == Key.S || e.Key == Key.D))
                {
                    if (!player1KeyProcessed)
                    {
                        HandleIncorrectKey(Player.Player1);
                        player1KeyProcessed = true;
                    }
                    return;
                }
                else if (keyToPressPlayer1 == Key.A && (e.Key == Key.W || e.Key == Key.S || e.Key == Key.D))
                {
                    if (!player1KeyProcessed)
                    {
                        HandleIncorrectKey(Player.Player1);
                        player1KeyProcessed = true;
                    }
                    return;
                }
                else if (keyToPressPlayer1 == Key.S && (e.Key == Key.A || e.Key == Key.W || e.Key == Key.D))
                {
                    if (!player1KeyProcessed)
                    {
                        HandleIncorrectKey(Player.Player1);
                        player1KeyProcessed = true;
                    }
                    return;
                }
                else if (keyToPressPlayer1 == Key.D && (e.Key == Key.A || e.Key == Key.S || e.Key == Key.W))
                {
                    if (!player1KeyProcessed)
                    {
                        HandleIncorrectKey(Player.Player1);
                        player1KeyProcessed = true;
                    }
                    return;
                }


            }
            // player 2 control check. Checkt ook of er die animatieronde al een toets is aangeslagen.
            // Dit betekend: dezelfde animatieronde kun je maar 1 toetsaanslag doen, en die registreert min of plus punten.
            // je kunt geen twee aanslagen doen.
            if (frameIndex >= 9 && frameIndex <= 15)
            {
                if (keyToPressPlayer2 == Key.Up && e.Key == Key.Up)
                {
                    if (!player2KeyProcessed)
                    {
                        HandleCorrectKey(Player.Player2);
                        player2KeyProcessed = true;
                    }
                    return;
                }
                else if (keyToPressPlayer2 == Key.Down && e.Key == Key.Down)
                {
                    if (!player2KeyProcessed)
                    {
                        HandleCorrectKey(Player.Player2);
                        player2KeyProcessed = true;
                    }
                    return;
                }
                else if (keyToPressPlayer2 == Key.Left && e.Key == Key.Left)
                {
                    if (!player2KeyProcessed)
                    {
                        HandleCorrectKey(Player.Player2);
                        player2KeyProcessed = true;
                    }
                    return;
                }
                else if (keyToPressPlayer2 == Key.Right && e.Key == Key.Right)
                {
                    if (!player2KeyProcessed)
                    {
                        HandleCorrectKey(Player.Player2);
                        player2KeyProcessed = true;
                    }
                    return;
                }
                else if (keyToPressPlayer2 == Key.Up && (e.Key == Key.Right || e.Key == Key.Down || e.Key == Key.Left))
                {
                    if (!player2KeyProcessed)
                    {
                        HandleIncorrectKey(Player.Player2);
                        player2KeyProcessed = true;
                    }
                    return;
                }
                else if (keyToPressPlayer2 == Key.Down && (e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Left))
                {
                    if (!player2KeyProcessed)
                    {
                        HandleIncorrectKey(Player.Player2);
                        player2KeyProcessed = true;
                    }
                    return;
                }
                else if (keyToPressPlayer2 == Key.Left && (e.Key == Key.Right || e.Key == Key.Down || e.Key == Key.Up))
                {
                    if (!player2KeyProcessed)
                    {
                        HandleIncorrectKey(Player.Player2);
                        player2KeyProcessed = true;
                    }
                    return;
                }
                else if (keyToPressPlayer2 == Key.Right && (e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Left))
                {
                    if (!player2KeyProcessed)
                    {
                        HandleIncorrectKey(Player.Player2);
                        player2KeyProcessed = true;
                    }
                    return;
                }
            }

            // Mocht een speler buiten de juiste frame een toets in drukken, dan geld er punt aftrek. Minus 5 punten in dit geval!
            // Speler 1
            if (!player1KeyProcessed && IsPlayer1Key(e.Key) && !(frameIndex >= 9 && frameIndex <= 15))
            {
                player1Score -= 5;
                player1ScoreText.Text = $"Player 1: {player1Score}";
                player1KeyProcessed = true;
            }

            // Mocht een speler buiten de juiste frame een toets in drukken, dan geld er punt aftrek. Minus 5 punten in dit geval!
            // Speler 2
            if (!player2KeyProcessed && IsPlayer2Key(e.Key) && !(frameIndex >= 9 && frameIndex <= 15))
            {
                player2Score -= 5;
                player2ScoreText.Text = $"Player 2: {player2Score}";
                player2KeyProcessed = true;
            }
        }


        // Onderstaande behandeld een juiste key input. plus 10 punten!
        private void HandleCorrectKey(Player player)
        {
            if (player == Player.Player1)
            {
                player1Score += 10;
                player1ScoreText.Text = $"Player 1: {player1Score}";
            }
            else if (player == Player.Player2)
            {
                player2Score += 10;
                player2ScoreText.Text = $"Player 2: {player2Score}";
            }
        }


        // Onderstaande behandeld een foute key input. min 2 punten!
        private void HandleIncorrectKey(Player player)
        {
            if (player == Player.Player1)
            {
                player1Score -= 2;
                player1ScoreText.Text = $"Player 1: {player1Score}";
            }
            else if (player == Player.Player2)
            {
                player2Score -= 2;
                player2ScoreText.Text = $"Player 2: {player2Score}";
            }
        }
    }
}

// enum om spelers te selecteren in de code.
enum Player
{
    Player1,
    Player2
}