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
    /// Interaction logic for instellingen_startspel.xaml
    /// </summary>
    public partial class instellingen_startspel : Window
    {
        public instellingen_startspel()
        {
            InitializeComponent();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            StartSpel startSpel = new StartSpel();
            startSpel.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
