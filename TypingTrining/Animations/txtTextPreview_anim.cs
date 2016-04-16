using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Animation;
using System.Windows.Controls;

namespace TypingTrining.Animations
{
    static public class txtTextPreview_anim
    {
        static public void OpacityShowUp(TextBox txt, Label lbl)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = txt.Opacity;
            da.To = 1;
            da.Duration = TimeSpan.FromSeconds(0.5);
            txt.BeginAnimation(TextBox.OpacityProperty, da);
            da.To = 0.6;
            lbl.BeginAnimation(TextBox.OpacityProperty, da);
        }

        static public void OpactiyShowOff(TextBox txt, Label lbl)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = txt.Opacity;
            da.To = 0;
            da.Duration = TimeSpan.FromSeconds(0.3);
            txt.BeginAnimation(TextBox.OpacityProperty, da);
            da.To = 0;
            lbl.BeginAnimation(TextBox.OpacityProperty, da);
        }
    }
}
