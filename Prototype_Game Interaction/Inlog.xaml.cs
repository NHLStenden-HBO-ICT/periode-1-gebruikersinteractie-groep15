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
    /// Interaction logic for Inlog.xaml
    /// </summary>
    public partial class Inlog : Window
    {
        public Inlog()
        {
            InitializeComponent();
        }

        private void inloggen_Click(object sender, RoutedEventArgs e)
        {
            if (wachtwoord.Password != "" && email.Text !="")
            {
                if(wachtwoord.Password == "test" && email.Text == "user")
                {
                    MainWindow main = new MainWindow();
                    main.Visibility = Visibility.Visible;
                    this.Close();
                }
            }
        }
    }
}
