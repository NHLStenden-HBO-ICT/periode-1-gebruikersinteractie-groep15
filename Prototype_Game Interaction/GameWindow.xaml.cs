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
        }

        // Het veranderen van window van spel scherm naar pauze scherm moet nog wel veranderd worden dat dit met een toets op het toetsen bord gebeurd.
        private void PauzeClick (object sender, RoutedEventArgs e) 
        {
            SharedData.CurrentScreen = "PauzeMenu";

            PauzeMenu pauzeMenu = new PauzeMenu();
            pauzeMenu.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
    }
}
