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
    public class Game
    {
        //поле
        private Square[,] field;

        public Game()
        {
            field = new Square[3,3];
            int squareCount = 0;
            for (int i = 0, l = field.GetLength(0); i < l; i++)
            {
                for (int j = 0, l2 = field.GetLength(1); j < l2; j++)
                {
                    field[i,j] = new Square();
                    squareCount++;
                }
            }
        }

        public Square[,] getField()
        {
            return field;
        }

        }
}