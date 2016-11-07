using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace KrestikiNoliki
{
    [Activity(Label = "KrestikiNoliki", MainLauncher = true, Icon = "@drawable/icon")]
    public class KrestiliNolikiActivity : Activity
    {
        int count = 1;
        private TableLayout layout;
        public KrestikinolikiActivity()
        {
            game = new Game();
            game.start(); // будет реализован позже
        }


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.TableLayout);
            TableLayout layout = (TableLayout)FindViewById(Resource.Id.main_l);
            // Get our button from the layout resource,
            // and attach an event to it
            buildGameField();

        }
    }
}

