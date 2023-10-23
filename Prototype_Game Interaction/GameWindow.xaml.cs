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
using Prototype_Game_Interaction;


namespace Prototype_Game_Interaction
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
            this.KeyDown += PauzeMenu_keyDown; // voor de knop om naar het pauze menu te gaan
            this.KeyDown += Button1_keyDown;
            
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
