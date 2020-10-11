using System;
using System.Collections.Generic;
using System.Text;

namespace TikTacToeWorkshop
{
    public class TikTakToe
    {
        private char[] board;

        char userLetter, compLetter;

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

        public int UC6_Toss()
        {
            const int user = 0;
            const int comp = 1;

            Random random = new Random();
            int toss = random.Next(0,2);
            if (toss == user)
            {
                Console.WriteLine("User Won the Toss");
                Console.WriteLine("User's Turn!!!");
                UC4_MakeMove(userLetter);
                return user;
            }
            else
            {
                Console.WriteLine("Computer Won the Toss");
                if (userLetter == 'X' || userLetter == 'x')
                {
                    Console.WriteLine("Computer's Turn!!!");
                    UC8_ComputerMove('O');
                }
                if (userLetter == 'O' || userLetter == 'o')
                {
                    Console.WriteLine("Computer's Turn!!!");
                    UC8_ComputerMove('X');
                }
                return comp;
            }
        }

        public void UC8_ComputerMove(char completter)
        {
            int markposition;
            while (true)
            {
                Random random = new Random();
                markposition = random.Next(1,10);
                if(board[markposition].Equals(' '))
                {
                    board[markposition] = completter;
                    break;
                }
            }
            UC3_displayBoard();
        }
    }
}
