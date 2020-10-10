using System;
using System.Collections.Generic;
using System.Text;

namespace TikTacToeWorkshop
{
    public class TikTakToe
    {
        private char[] board;

        public TikTakToe()
        {
            board = new char[10];
        }

        //Initialize board
        public void UC1_StartGame()
        {
            for (int position = 1; position < board.Length; position++)
            {
                board[position] = ' ';
            }
            Console.WriteLine("Board has been initialized");
        }
        public char UC2_SelectCharacter()//Choose one letter X or O
        {
            Console.WriteLine("Select X or O");
            char userLetter = Convert.ToChar(Console.ReadLine());
            char compLetter = ' '; 

            if (userLetter == 'X')
            {
                compLetter = 'O';
            }
            else if (userLetter == 'O')
            {
                compLetter = 'X';
            }
            else
            {
                Console.WriteLine("Invalid Character");
            }
            Console.WriteLine("User Selected: " + userLetter);
            return compLetter;

        }
    }
}
