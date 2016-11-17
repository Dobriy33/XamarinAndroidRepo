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
    class WinnerCheckerDiagonalRight : IWinnerChecker
    {
        private Game game;

        public WinnerCheckerDiagonalRight(Game game)
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
                currPlayer = field[i,len - (i + 1)].getPlayer();
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