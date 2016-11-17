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

    public interface IWinnerChecker
    {
        Player checkWinner();
    }
    public class Game
    {
        // ������
        private Player[] players;

        //����
        private Square[,] field;

        //������ �� ����
        private bool started;

        //������� �����
        private Player activePlayer;

        //������� ���������� ����������� �����
        private int filled;

        //����� �����
        private int squareCount;

        private IWinnerChecker[] winnerCheckers;



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
            players = new Player[2];
            started = false;
            activePlayer = null;
            filled = 0;

            winnerCheckers = new IWinnerChecker[4];
            winnerCheckers[0] = new WinnerCheckerHorizontal(this);
            winnerCheckers[1] = new WinnerCheckerVertical(this);
            winnerCheckers[2] = new WinnerCheckerDiagonalLeft(this);
            winnerCheckers[3] = new WinnerCheckerDiagonalRight(this);
        }

        public void start()
        {
            resetPlayers();
            started = true;
        }

        private void resetPlayers()
        {
            players[0] = new Player("X");
            players[1] = new Player("O");
            setCurrentActivePlayer(players[0]);
        }

        public Square[,] getField()
        {
            return field;
        }

        private void setCurrentActivePlayer(Player player)
        {
            activePlayer = player;
        }

        public bool makeTurn(int x, int y)   //
        {
            if (field[x, y].isFilled())
            {
                return false;
            }
            field[x, y].fill(getCurrentActivePlayer());
            filled++;
            switchPlayers();
            return true;
        }

        private void switchPlayers()
        {
            activePlayer = (activePlayer == players[0]) ? players[1] : players[0];
        }

        public Player getCurrentActivePlayer()
        {
            return activePlayer;
        }

        public bool isFieldFilled() 
        {
            return squareCount == filled;
        }

        public void reset()
        {
            resetField();
            resetPlayers();
        }

        private void resetField()
        {
            for (int i = 0, l = field.GetLength(0); i < l; i++)
            {
                for (int j = 0, l2 = field.GetLength(1); j < l2; j++)
                {
                    field[i,j].fill(null);
                }
            }
            filled = 0;
        }

       
        }
}