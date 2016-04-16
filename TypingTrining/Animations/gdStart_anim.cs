using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace TypingTrining.Animations
{
    static public class gdStart_anim
    {
        static public void OpacityShowUp(Grid gd)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = gd.Opacity;
            da.To = 1;
            da.Duration = TimeSpan.FromSeconds(0.5);
            gd.BeginAnimation(Grid.OpacityProperty, da);
        }

        static public void OpacityShowDown(Grid gd)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = gd.Opacity;
            da.To = 0;
            da.Duration = TimeSpan.FromSeconds(0.5);
            gd.BeginAnimation(Grid.OpacityProperty, da);
        }
    }
}
