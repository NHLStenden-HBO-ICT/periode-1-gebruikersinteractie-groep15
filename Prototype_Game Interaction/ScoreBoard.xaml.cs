using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.IO;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Data.Sqlite;
using Prototype_Game_Interaction;
using Microsoft.Data.SqlClient;
using System.Data.SQLite;

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
            this.KeyDown += MainWindow_keyDown; // voor de knop om terug te gaan naar het hoofdmenu
            FillDataGrid();
        }



        private void FillDataGrid()
        {
            string relativePath = "GameScores.db";
            string currentFolder = AppDomain.CurrentDomain.BaseDirectory;
            string databasePath = System.IO.Path.Combine(currentFolder, relativePath); 
            string connectionString = $@"Data Source={databasePath};Version=3;";

            using (var conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string cmdString = "SELECT Scores, Gebruikersnaam FROM Scores";
                    using (var cmd = new SQLiteCommand(cmdString, conn))
                    {
                        using (var sda = new SQLiteDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable("Scores");
                            sda.Fill(dt);
                            Scores.ItemsSource = dt.DefaultView; 
                        }
                    }
                }
                catch (System.Data.SQLite.SQLiteException ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void MainWindowClick(object sender, RoutedEventArgs e)
        {
            SharedData.CurrentScreen = "MainWindow";
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void MainWindow_keyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
        
        private void Scores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
