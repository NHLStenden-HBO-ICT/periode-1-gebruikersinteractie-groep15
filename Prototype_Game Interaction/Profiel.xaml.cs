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
    public partial class Profiel : Window
    {
        private Person _person;

        public Profiel()
        {
            InitializeComponent();

            _person = new Person
            {
                Name = "Test",
                Email = "Test",
                Password = "Test",
                Postcode = "Test"
            };

            this.DataContext = _person;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Name: {_person.Name}");
            MessageBox.Show($"Email: {_person.Email}");
            MessageBox.Show($"Password: {_person.Password}");
            MessageBox.Show($"Postcode: {_person.Postcode}");
        }

        private void ZekerheidClick(object sender, RoutedEventArgs e)
        {
            // Voor de knop om naar het beginscherm te gaan, maar je moet eerst nog bevestigingen in een ander menu verwerken.
            SharedData.CurrentScreen = "BevestigingsMenu";

            ZekerheidMenu zekerheidMenu = new ZekerheidMenu();
            zekerheidMenu.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Postcode { get; set; }

        public Person()
        {
            
        }
    }
}
