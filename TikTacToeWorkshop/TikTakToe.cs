using System;
using System.Collections.Generic;
using System.Text;

namespace TikTacToeWorkshop
{
    public class TikTakToe
    {
        private char[] board;

        //Initialize borad
        public void UC1_StartGame()
        {
            board = new char[10];
            for (int position = 1; position < board.Length; position++)
            {
                board[position] = ' ';
            }
        }
    }
}
