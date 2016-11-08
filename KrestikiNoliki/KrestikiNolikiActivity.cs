﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace KrestikiNoliki
{
    [Activity(Label = "KrestikiNoliki", MainLauncher = true, Icon = "@drawable/icon")]
    public class KrestikiNolikiActivity : Activity
    {
        int count = 1;
        private TableLayout layout;
        public KrestikiNolikiActivity()
        {
            //Game game = new Game();
           // game.start(); // будет реализован позже
        }


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.TableLayout);
           // TableLayout layout = (TableLayout)FindViewById(Resource.Id.main_l);
            // Get our button from the layout resource,
            // and attach an event to it
            buildGameField();

        }

        private Button[,] buttons = new Button[3,3];
        //(....)
        private void buildGameField()
        {
            Game game = new Game();
            TableLayout layout = (TableLayout)FindViewById(Resource.Id.main_l);

            Square[,] field = game.getField();
            for (int i = 0, lenI = field.GetLength(0); i < lenI; i++)
            {
                TableRow row = new TableRow(this); // создание строки таблицы
                for (int j = 0, lenJ = field.GetLength(1); j < lenJ; j++) /*field[i,j]*/ //GetLength возвращает длину массива в измерении (i) измерения считаюся с 0
                {
                    Button button = new Button(this);
                    buttons[i,j] = button;
                    button.Click += (sender, e) => {
                        button.Text = "+";
                    };                   //SetOnClickListener(new Listener(i, j)); // установка слушателя, реагирующего на клик по кнопке
                    row.AddView(button, new TableRow.LayoutParams(TableRow.LayoutParams.WrapContent,
                            TableRow.LayoutParams.WrapContent)); // добавление кнопки в строку таблицы
                    button.SetWidth(107);
                    button.SetHeight(107);
                }
                layout.AddView(row, new TableLayout.LayoutParams(TableLayout.LayoutParams.WrapContent,
                        TableLayout.LayoutParams.WrapContent)); // добавление строки в таблицу
            }
        }
    }
}
