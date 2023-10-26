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
        private int frameIndex = 0;
        private int frameWidth = 32;
        private int frameHeight = 32;
        private int totalFrames = 22;
        private DispatcherTimer animationTimer;

        public GameWindow()
        {
            InitializeComponent();
            this.KeyDown += PauzeMenu_keyDown; // voor de knop om naar het pauze menu te gaan
            this.KeyDown += Button1_keyDown;
            
            // Start the animation timer
            animationTimer = new DispatcherTimer();
            animationTimer.Interval = TimeSpan.FromMilliseconds(18);
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
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

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Update the frame index
            frameIndex = (frameIndex + 1) % totalFrames;

            // Calculate the position of the current frame in the sprite sheet
            int x = frameIndex * frameWidth;
            int y = 0;

            // Create a new CroppedBitmap that displays the current frame
            CroppedBitmap frame = new CroppedBitmap(new BitmapImage(new Uri("Assets/player1 curl-Sheet.png", UriKind.Relative)), new Int32Rect(x, y, frameWidth, frameHeight));

            // Update the Source property of the MyImage control to display the current frame
            Player1curl.Source = frame;
        }

    }
}
