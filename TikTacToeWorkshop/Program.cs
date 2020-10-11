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
            tk.UC4_MakeMove(userletter);
            int toss = tk.UC6_Toss();
        }
    }
}
