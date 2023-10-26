using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
using System.Windows.Threading;
using Prototype_Game_Interaction;
using static System.Net.Mime.MediaTypeNames;


namespace Prototype_Game_Interaction
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private int frameIndex = 1;
        private int frameWidth = 512;
        private int frameHeight = 512;
        private int totalFrames = 22;
        private bool isAnimationRunning = false;
        private DispatcherTimer animationTimer;
        BitmapImage spriteSheet = new BitmapImage(new Uri("Assets/player1curlSheet.png", UriKind.Relative));

        public GameWindow()
        {
            InitializeComponent();

            ShowPlayer1Frame();

            this.KeyDown += Button1_keyDown;
            this.KeyDown += Button5_keyDown;
            this.KeyUp += Button1_keyUp;


            // Start the animation timer
            animationTimer = new DispatcherTimer();
            animationTimer.Interval = TimeSpan.FromMilliseconds(25);
            animationTimer.Tick += AnimationTimer_Tick;

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

        private void Button5_keyDown(object sender, KeyEventArgs e)
        {
            // dit is als test om te kijken of de knop werkt
            if (e.Key == Key.Enter)
            {
                knop.Text = "Nee mag niet!!";
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Update the frame index
            frameIndex++;
            // dit checkt of alle frames zijn afgespeeld van de sprite sheet
            if (frameIndex >= totalFrames)
            {
                // Stop the animation
                animationTimer.Stop();
                return;
            }


            // Calculate the position of the current frame in the sprite sheet
            int x = frameIndex * frameWidth;
            int y = 0;

            // Create a new CroppedBitmap that displays the current frame
            CroppedBitmap frame = new CroppedBitmap(spriteSheet, new Int32Rect(x, y, frameWidth, frameHeight));
            



            // Update the Source property of the MyImage control to display the current frame
            Player1curl.Source = frame;
        }

        private void ShowPlayer1Frame()
        {
            int x = frameIndex * frameWidth;
            int y = 0;
            CroppedBitmap frame = new CroppedBitmap(spriteSheet, new Int32Rect(x, y, frameWidth, frameHeight));
            Player1curl.Source = frame;
        }
        private void Button1_keyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                if (animationTimer.IsEnabled == false)
                {
                    // Reset de frameIndex naar 0
                     // Toon de eerste frame voordat de animatie begint
                    animationTimer.Start();
                    if (frameIndex >= totalFrames)
                    {
                        animationTimer.Stop(); 
                    }
                }
            }
        }

        private void Button1_keyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                if (frameIndex >= totalFrames)
                {
                    // Reset de frameIndex naar 0
                    frameIndex = 1;
                }
            }
        }
    }
}
