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
            char userLetter, compLetter;
            while (true)
            {
                Console.WriteLine("Select X or O");
                userLetter = Convert.ToChar(Console.ReadLine());

                if (userLetter == 'X' || userLetter == 'x')
                {
                    compLetter = 'O';
                    break;
                }
                else if (userLetter == 'O' || userLetter == 'o')
                {
                    compLetter = 'X';
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Character");
                }
            }
            Console.WriteLine("User Selected: " + userLetter);
            return userLetter;

        }
        //Displays the Board
        public void UC3_displayBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1], board[2], board[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[4], board[5], board[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[7], board[8], board[9]);
            Console.WriteLine("     |     |      ");
        }

        public void UC4_MakeMove(char userletter)
        {
            int markposition;
            while (true)
            {
                Console.WriteLine("Enter the position where you want to mark X or O");
                markposition = Convert.ToInt32(Console.ReadLine());
                if (markposition<1 || markposition > 9)
                {
                    Console.WriteLine("Enter a valid position");
                }
                else if(!board[markposition].Equals(' '))
                {
                    Console.WriteLine("Position isn't empty");
                }
                else
                {
                    board[markposition] = userletter;
                    break;
                }
            }
            UC3_displayBoard();
        }
    }
}
