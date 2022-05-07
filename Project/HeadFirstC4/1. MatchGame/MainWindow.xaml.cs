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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1._MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            //Create a list of 8 pairs of emojis
            List<string> animalEmoji = new List<string>()
            {
                "🦧", "🦧",
                "🦉", "🦉",
                "🦚", "🦚",
                "🦩", "🦩",
                "🐞", "🐞",
                "🐉", "🐉",
                "🦥",  "🦥",
                "🦙",  "🦙"
            };

            //Create a new random number generator
            Random random = new Random();

            //Find every TextBlock in the main grid and repeate the following statement for each of them
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                //Pick a random number between 0 and the number of emojis left in the list and call it index
                int index = random.Next(animalEmoji.Count);

                //Use the random number called index to get a random emoji from the list
                string nextEmoji = animalEmoji[index];
                //Update the text block with the random emoji from the list
                textBlock.Text = nextEmoji;
                //Remove the random emoji from the list
                animalEmoji.RemoveAt(index);
            }
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock; 

            if(findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }
    }
}
