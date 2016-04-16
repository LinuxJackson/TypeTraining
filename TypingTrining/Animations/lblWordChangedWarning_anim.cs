using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace TypingTrining.Animations
{
    public static class lblWordChangedWarning_anim
    {
        static public void OpaciytShow(Label lbl)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = lbl.Opacity;
            da.To = 1;
            da.Duration = TimeSpan.FromSeconds(2);
            da.AutoReverse = true;
            da.RepeatBehavior = new RepeatBehavior(3);
            lbl.BeginAnimation(Label.OpacityProperty, da);
        }
    }
}
