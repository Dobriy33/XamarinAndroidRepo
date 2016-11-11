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
    public class Square
    {
        private Player player = null;

        public void fill(Player player)
        {
            this.player = player;
        }

        public Boolean isFilled()
        {
            if (player != null) {
                return true;
            }
            return false;
        }

        public Player getPlayer()
        {
            return player;
        }
    }

}