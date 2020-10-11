using System;

namespace TikTacToeWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TikTakToe Game");

            TikTakToe tk = new TikTakToe();

            tk.UC1_StartGame();

            char userletter = tk.UC2_SelectCharacter();

            tk.UC3_displayBoard();

            int toss = tk.UC6_Toss();

            int c = 1;

            while (c < 9)
            {
                if (toss == 0)
                {
                    if (userletter == 'X' || userletter == 'x')
                    {
                        Console.WriteLine("Computer's Turn!!!");
                        tk.UC8_ComputerMove('O');
                        c++;
                        Console.WriteLine("User's Turn!!!");
                        tk.UC4_MakeMove(userletter);
                        c++;
                    }
                    if (userletter == 'O' || userletter == 'o')
                    {
                        Console.WriteLine("Computer's Turn!!!");
                        tk.UC8_ComputerMove('X');
                        c++;
                        Console.WriteLine("User's Turn!!!");
                        tk.UC4_MakeMove(userletter);
                        c++;
                    }
                }
                if (toss == 1)
                {
                    Console.WriteLine("User's Turn!!!");
                    tk.UC4_MakeMove(userletter);
                    c++;
                    if (userletter == 'X' || userletter == 'x')
                    {
                        Console.WriteLine("Computer's Turn!!!");
                        tk.UC8_ComputerMove('O');
                        c++;
                    }
                    if (userletter == 'O' || userletter == 'o')
                    {
                        Console.WriteLine("Computer's Turn!!!");
                        tk.UC8_ComputerMove('X');
                        c++;
                    }
                }
            }
        }
    }
}
