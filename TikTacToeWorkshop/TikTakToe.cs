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
                    UC9_ComputerMoveToBlock('O');
                }
                if (userLetter == 'O' || userLetter == 'o')
                {
                    Console.WriteLine("Computer's Turn!!!");
                    UC9_ComputerMoveToBlock('X');
                }
                return comp;
            }
        }

        public void UC7_DetermineResultsPerMove(int toss)
        {
            int c = 2;
            int flag = 0;
            while (true)
            {
                if ((board[1] == userLetter && board[2] == userLetter && board[3] == userLetter) ||
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

                if (c >= 10) //this 10th iteration will only compare board[] values and then control will come on this line and will break the loop
                {
                    break;
                }

                if (toss == 0)
                {
                    if (userLetter == 'X' || userLetter == 'x')
                    {
                        Console.WriteLine("Computer's Turn!!!");
                        UC9_ComputerMoveToBlock('O');
                        c++;
                        Console.WriteLine("User's Turn!!!");
                        UC4_MakeMove(userLetter);
                        c++;
                    }
                    if (userLetter == 'O' || userLetter == 'o')
                    {
                        Console.WriteLine("Computer's Turn!!!");
                        UC9_ComputerMoveToBlock('X');
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
                        UC9_ComputerMoveToBlock('O');
                        c++;
                    }
                    if (userLetter == 'O' || userLetter == 'o')
                    {
                        Console.WriteLine("Computer's Turn!!!");
                        UC9_ComputerMoveToBlock('X');
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

        public void UC9_ComputerMoveToBlock(char completter)
        {
            int markposition;
            while (true)
            {
                char user = char.ToLower(userLetter);
                int flag_row = 0;


                //for horizontal and diagonal rows
                for (int i = 0; i <= 6; i += 3)
                {

                    if ((char.ToLower(board[i+1]).Equals(user)) && (char.ToLower(board[i+2]).Equals(user)))
                    {
                        if (board[i+3].Equals(' '))
                        {
                            markposition = i + 3;
                            board[markposition] = completter;
                            flag_row = 1;
                            break;
                        }                   
                        
                    }
                    if ((char.ToLower(board[i+2]).Equals(user)) && (char.ToLower(board[i+3]).Equals(user)))
                    { 
                        if (board[i + 1].Equals(' '))
                        {
                            markposition = i + 1;
                            board[markposition] = completter;
                            flag_row = 1;
                            break;
                        }                       
                        
                    }
                    if ((char.ToLower(board[i+1]).Equals(user)) && (char.ToLower(board[i+3]).Equals(user)))
                    {
                        if (board[i + 2].Equals(' '))
                        {
                            markposition = i + 2;
                            board[markposition] = completter;
                            flag_row = 1;
                            break;
                        }                       
                       
                    }

                    //for diagonals
                    if ((char.ToLower(board[1]).Equals(user)) && (char.ToLower(board[5]).Equals(user)))
                    {
                        if (board[9].Equals(' ') && flag_row == 0)
                        {
                            markposition = 9;
                            board[markposition] = completter;
                            flag_row = 1;
                            break;
                        }

                    }
                    if ((char.ToLower(board[5]).Equals(user)) && (char.ToLower(board[9]).Equals(user)))
                    {
                        if (board[1].Equals(' ') && flag_row == 0)
                        {
                            markposition = 1;
                            board[markposition] = completter;
                            flag_row = 1;
                            break;
                        }

                    }
                    if ((char.ToLower(board[1]).Equals(user)) && (char.ToLower(board[9]).Equals(user)))
                    {
                        if (board[5].Equals(' ') && flag_row == 0)
                        {
                            markposition = 5;
                            board[markposition] = completter;
                            flag_row = 1;
                            break;
                        }

                    }

                    if ((char.ToLower(board[3]).Equals(user)) && (char.ToLower(board[5]).Equals(user)))
                    {
                        if (board[7].Equals(' ') && flag_row == 0)
                        {
                            markposition = 7;
                            board[markposition] = completter;
                            flag_row = 1;
                            break;
                        }

                    }
                    if ((char.ToLower(board[3]).Equals(user)) && (char.ToLower(board[7]).Equals(user)))
                    {
                        if (board[5].Equals(' ') && flag_row == 0)
                        {
                            markposition = 5;
                            board[markposition] = completter;
                            flag_row = 1;
                            break;
                        }

                    }
                    if ((char.ToLower(board[5]).Equals(user)) && (char.ToLower(board[7]).Equals(user)))
                    {
                        if (board[3].Equals(' ') && flag_row == 0)
                        {
                            markposition = 3;
                            board[markposition] = completter;
                            flag_row = 1;
                            break;
                        }

                    }

                }

                //For vertical columns and diagonals
                if (flag_row == 0)   //if row isn't blocked, it will try for column 
                {
                    for (int i = 0; i < 3; i++)
                    {

                        if ((char.ToLower(board[i + 1]).Equals(user)) && (char.ToLower(board[i + 4]).Equals(user)))
                        {
                            if (board[i + 7].Equals(' '))
                            {
                                markposition = i + 7;
                                board[markposition] = completter;
                                flag_row = 1;
                                break;
                            }

                        }
                        if ((char.ToLower(board[i + 1]).Equals(user)) && (char.ToLower(board[i + 7]).Equals(user)))
                        {
                            if (board[i + 4].Equals(' '))
                            {
                                markposition = i + 4;
                                board[markposition] = completter;
                                flag_row = 1;
                                break;
                            }

                        }
                        if ((char.ToLower(board[i + 4]).Equals(user)) && (char.ToLower(board[i + 7]).Equals(user)))
                        {
                            if (board[i + 1].Equals(' '))
                            {
                                markposition = i + 1;
                                board[markposition] = completter;
                                flag_row = 1;
                                break;
                            }

                        }

                        //for diagonals
                            if ((char.ToLower(board[1]).Equals(user)) && (char.ToLower(board[5]).Equals(user)))
                            {
                                if (board[9].Equals(' ') && flag_row == 0)
                                {
                                    markposition = 9;
                                    board[markposition] = completter;
                                    flag_row = 1;
                                    break;
                                }

                            }
                            if ((char.ToLower(board[5]).Equals(user)) && (char.ToLower(board[9]).Equals(user)))
                            {
                                if (board[1].Equals(' ') && flag_row == 0)
                                {
                                    markposition = 1;
                                    board[markposition] = completter;
                                    flag_row = 1;
                                    break;
                                }

                            }
                            if ((char.ToLower(board[1]).Equals(user)) && (char.ToLower(board[9]).Equals(user)))
                            {
                                if (board[5].Equals(' ') && flag_row == 0)
                                {
                                    markposition = 5;
                                    board[markposition] = completter;
                                    flag_row = 1;
                                    break;
                                }

                            }

                            if ((char.ToLower(board[3]).Equals(user)) && (char.ToLower(board[5]).Equals(user)))
                            {
                                if (board[7].Equals(' ') && flag_row == 0)
                                {
                                    markposition = 7;
                                    board[markposition] = completter;
                                    flag_row = 1;
                                    break;
                                }

                            }
                            if ((char.ToLower(board[3]).Equals(user)) && (char.ToLower(board[7]).Equals(user)))
                            {
                                if (board[5].Equals(' ') && flag_row == 0)
                                {
                                    markposition = 5;
                                    board[markposition] = completter;
                                    flag_row = 1;
                                    break;
                                }

                            }
                            if ((char.ToLower(board[5]).Equals(user)) && (char.ToLower(board[7]).Equals(user)))
                            {
                                if (board[3].Equals(' ') && flag_row == 0)
                                {
                                    markposition = 3;
                                    board[markposition] = completter;
                                    flag_row = 1;
                                    break;
                                }

                            }
                    }
                    //first user's move will be blocked, then it will choose corner
                    UC10_TakeAvailableCorners(ref completter,ref flag_row);

                }

                if (flag_row == 0) //if both row and column are not blocked, then it random position will get marked
                {                
                    while (true)
                    {
                        Random random = new Random();
                        markposition = random.Next(1, 10);
                        if (board[markposition].Equals(' '))
                        {
                            board[markposition] = completter;
                            break;
                        }
                    }
                }
                break;

            }
            UC3_displayBoard();
        }

        public void UC10_TakeAvailableCorners(ref char completter,ref int flag_row)
        {
            int[] corner = { 1, 3, 7, 9 };

            foreach (int i in corner)
            {
                if (board[i].Equals(' ') && flag_row==0)
                {
                    board[i] = completter;
                    flag_row = 1;
                    break;
                }
            }
            if (flag_row == 0)
            {
                UC11_TakeSubsequentMoves(ref completter, ref flag_row);
                /*if (board[5].Equals(' '))
                {
                    board[5] = completter;
                    flag_row = 1;
                }*/
            }
        }

        public void UC11_TakeSubsequentMoves(ref char completter, ref int flag_row)
        {
            if(board[5].Equals(' '))
            {
                board[5] = completter;
                flag_row = 1;
            }
            else
            {
                flag_row = 0;
            }
        }

    }
}
