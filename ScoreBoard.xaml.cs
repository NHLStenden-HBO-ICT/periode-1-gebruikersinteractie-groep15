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
    /// Interaction logic for ScoreBoard.xaml
    /// </summary>
    public partial class ScoreBoard : Window
    {
        public ScoreBoard()
        {
            InitializeComponent();
        }


        private void ZekerheidClick(object sender, RoutedEventArgs e)
        {
            // voor de knop om naar het begin menu te gaan maar je moet eerst nog dat bevestingen in een ander menu
            SharedData.CurrentScreen = "ConformatieMenu";

            ZekerheidMenu zekerheidMenu = new ZekerheidMenu();
            zekerheidMenu.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        }
    }


