﻿using System;

namespace TikTacToeWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TikTakToe Game");
            TikTakToe tk = new TikTakToe();
            tk.UC1_StartGame();
            char completter = tk.UC2_SelectCharacter();
            tk.UC3_displayBoard();
        }
    }
}
