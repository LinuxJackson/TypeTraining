using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Animation;
using System.Windows.Controls;

namespace TypingTrining.Animations
{
    static public class TypeComplete
    {
        static Label lbl1;
        static Label lbl2;

        static public void OpacityShow(Label lblConplete, Label lblTime, Label lblSpeed)
        {
            lbl1 = lblTime;
            lbl2 = lblSpeed;
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 1;
            da.Duration = TimeSpan.FromSeconds(1);
            da.Completed += Da_Completed1;
            lblConplete.BeginAnimation(Label.OpacityProperty, da);
        }

        private static void Da_Completed1(object sender, EventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 1;
            da.Duration = TimeSpan.FromSeconds(0.5);
            da.Completed += Da_Completed2;
            lbl1.BeginAnimation(Label.OpacityProperty, da);
        }

        private static void Da_Completed2(object sender, EventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 1;
            da.Duration = TimeSpan.FromSeconds(0.5);
            lbl2.BeginAnimation(Label.OpacityProperty, da);
        }
    }
}
