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
    class WinnerCheckerVertical : IWinnerChecker
    {
        private Game game;

        public WinnerCheckerVertical(Game game)
        {
            this.game = game;
        }
        public Player checkWinner()
        {
            Square[,] field = game.getField();
            Player currPlayer;
            Player lastPlayer = null;
            for (int i = 0, len = field.GetLength(0); i < len; i++)
            {
                lastPlayer = null;
                int successCounter = 1;
                for (int j = 0, len2 = field.GetLength(1); j < len2; j++)
                {
                    currPlayer = field[j,i].getPlayer();
                    if (currPlayer == lastPlayer && (currPlayer != null && lastPlayer != null))
                    {
                        successCounter++;
                        if (successCounter == len2)
                        {
                            return currPlayer;
                        }
                    }
                    lastPlayer = currPlayer;
                }
            }
            return null;
        }
    }
}