using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace KrestikiNoliki
{
    class WinnerCheckerDiagonalLeft
    {
        private Game game;

        public WinnerCheckerDiagonalLeft(Game game)
        {
            this.game = game;
        }

        public Player checkWinner()
        {
            Square[,] field = game.getField();
            Player currPlayer;
            Player lastPlayer = null;
            int successCounter = 1;
            for (int i = 0, len = field.GetLength(0); i < len; i++)
            {
                currPlayer = field[i,i].getPlayer();
                if (currPlayer != null)
                {
                    if (lastPlayer == currPlayer)
                    {
                        successCounter++;
                        if (successCounter == len)
                        {
                            return currPlayer;
                        }
                    }
                }
                lastPlayer = currPlayer;
            }
            return null;
        }
    }
}