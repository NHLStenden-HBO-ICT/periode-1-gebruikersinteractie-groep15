﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Prototype_Game_Interaction;

namespace Prototype_Game_Interaction
{

    public partial class Instellingen : Window
    {
        private int initialValueMuziek = 0; // Het oorspronkelijke getal
        private int initialValueGeluid = 0; // Het oorspronkelijke getal


        public Instellingen()
        {
            InitializeComponent();
            this.KeyDown += MainWindow_keyDown;
            muziekSlider.ValueChanged += MuziekSlider_ValueChanged;
            geluidSlider.ValueChanged += GeluidSlider_ValueChanged;
        }

        private void MuziekSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Hier berekenen we de nieuwe waarde van de TextBlock op basis van de sliderwaarde.
            // Je kunt de berekening aanpassen op basis van je vereisten.
            int newValue = initialValueMuziek + (int)muziekSlider.Value;

            // Zorg ervoor dat de nieuwe waarde niet onder de minimumwaarde gaat, bijvoorbeeld 0.
            if (newValue < 0)
            {
                newValue = 0;
            }

            // Stel de nieuwe waarde in voor de TextBlock
            muziekSliderVolume.Text = newValue.ToString();
        }

        private void GeluidSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Hier berekenen we de nieuwe waarde van de TextBlock op basis van de sliderwaarde.
            // Je kunt de berekening aanpassen op basis van je vereisten.
            int newValue = initialValueGeluid + (int)geluidSlider.Value;

            // Zorg ervoor dat de nieuwe waarde niet onder de minimumwaarde gaat, bijvoorbeeld 0.
            if (newValue < 0)
            {
                newValue = 0;
            }

            // Stel de nieuwe waarde in voor de TextBlock
            geluidSliderVolume.Text = newValue.ToString();
        }

        private void TeruggaanButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (SharedData.CurrentScreen == "StartSpel")
                {
                    StartSpel StartSpel = new StartSpel();
                    StartSpel.Visibility = Visibility.Visible;
                     
                }

                else if (SharedData.CurrentScreen == "PauzeMenu")
                {
                    PauzeMenu pauzeMenu = new PauzeMenu();
                    pauzeMenu.Visibility = Visibility.Visible;
                }
                
                else
                {
                    SharedData.CurrentScreen = "MainWindow";

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Visibility = Visibility.Visible;
                }
                this.Visibility = Visibility.Hidden;
            }    
        }

        private void MainWindow_keyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) 
            {
                {
                    if (SharedData.CurrentScreen == "StartSpel")
                    {
                        StartSpel StartSpel = new StartSpel();
                        StartSpel.Visibility = Visibility.Visible;

                    }

                    else if (SharedData.CurrentScreen == "PauzeMenu")
                    {
                        PauzeMenu pauzeMenu = new PauzeMenu();
                        pauzeMenu.Visibility = Visibility.Visible;
                    }

                    else
                    {
                        SharedData.CurrentScreen = "MainWindow";

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Visibility = Visibility.Visible;
                    }
                    this.Visibility = Visibility.Hidden;
                }
            }
        }

        private async void RollButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int rollResult = random.Next(1, 1000);
            resultLabel.Content = rollResult.ToString();

            // Een kleine delay tussen het getal en de tekst
            await Task.Delay(25);

            string[] randomTexts = new string[10]
        {
            "Wauwie!",
            "Knap zeg!",
            "Nutteloos dit...",
            "Wat een mooi getal!",
            "Hopsa!",
            "Wat is dit fantastisch!",
            "Wat een kut getal!",
            "Jij klikt wel graag op rollen, of niet?",
            "Dat is wel heel veel bier!",
            "Zoveel euro heb ik op de bank..."

        };

            int randomIndex = random.Next(randomTexts.Length);
            randomText.Text = randomTexts[randomIndex];
        }

    }
}