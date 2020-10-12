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

        public void UC7_DetermineResultsPerMove(int toss)
        {
            int c = 1;
            int flag = 0;
            while (c < 9)
            {
                if((board[1]==userLetter && board[2]==userLetter && board[3]==userLetter) ||
                    (board[4] == userLetter && board[5] == userLetter && board[6] == userLetter) ||
                    (board[7] == userLetter && board[8] == userLetter && board[9] == userLetter) ||
                    (board[1] == userLetter && board[5] == userLetter && board[9] == userLetter) ||
                    (board[3] == userLetter && board[5] == userLetter && board[7] == userLetter) ||
                    (board[1] == userLetter && board[4] == userLetter && board[7] == userLetter) ||
                    (board[2] == userLetter && board[5] == userLetter && board[8] == userLetter) ||
                    (board[3] == userLetter && board[6] == userLetter && board[9] == userLetter))
                {
                    Console.WriteLine("User has Won the Match. Thanks for Playing!!!");
                    flag = 1;
                    break;
                }
                if ((board[1] == compLetter && board[2] == compLetter && board[3] == compLetter) ||
                    (board[4] == compLetter && board[5] == compLetter && board[6] == compLetter) ||
                    (board[7] == compLetter && board[8] == compLetter && board[9] == compLetter) ||
                    (board[1] == compLetter && board[5] == compLetter && board[9] == compLetter) ||
                    (board[3] == compLetter && board[5] == compLetter && board[7] == compLetter) ||
                    (board[1] == compLetter && board[4] == compLetter && board[7] == compLetter) ||
                    (board[2] == compLetter && board[5] == compLetter && board[8] == compLetter) ||
                    (board[3] == compLetter && board[6] == compLetter && board[9] == compLetter))
                {
                    Console.WriteLine("Computer has Won the Match. Thanks for Playing!!!");
                    flag = 1;
                    break;
                }


                /*int j=0;
                for (int i = 1; i <= 9; i++)
                {                    
                    if(i==1 || i==4 || i == 7)
                    {
                        j+=2;
                    }
                }*/
                if (toss == 0)
                {
                    if (userLetter == 'X' || userLetter == 'x')
                    {
                        Console.WriteLine("Computer's Turn!!!");
                        UC8_ComputerMove('O');
                        c++;
                        Console.WriteLine("User's Turn!!!");
                        UC4_MakeMove(userLetter);
                        c++;
                    }
                    if (userLetter == 'O' || userLetter == 'o')
                    {
                        Console.WriteLine("Computer's Turn!!!");
                        UC8_ComputerMove('X');
                        c++;
                        Console.WriteLine("User's Turn!!!");
                        UC4_MakeMove(userLetter);
                        c++;
                    }
                }
                if (toss == 1)
                {
                    Console.WriteLine("User's Turn!!!");
                    UC4_MakeMove(userLetter);
                    c++;
                    if (userLetter == 'X' || userLetter == 'x')
                    {
                        Console.WriteLine("Computer's Turn!!!");
                        UC8_ComputerMove('O');
                        c++;
                    }
                    if (userLetter == 'O' || userLetter == 'o')
                    {
                        Console.WriteLine("Computer's Turn!!!");
                        UC8_ComputerMove('X');
                        c++;
                    }
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("Game has been Tied. Thanks for Playing");
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
