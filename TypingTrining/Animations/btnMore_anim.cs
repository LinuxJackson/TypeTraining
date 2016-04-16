using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace TypingTrining.Animations
{
    static public class btnMore_anim
    {
        static public void MarginShowUp(Button btn, Border bdr)
        {
            ThicknessAnimation tka = new ThicknessAnimation();
            tka.From = btn.Margin;
            tka.To = new System.Windows.Thickness(525 - 100 - 42 - 2, btn.Margin.Top, 0, 0);
            tka.Duration = TimeSpan.FromSeconds(0.6);
            tka.AccelerationRatio = 0.2;
            tka.DecelerationRatio = 0.8;
            btn.BeginAnimation(Button.MarginProperty, tka);

            tka = new ThicknessAnimation();
            tka.From = bdr.Margin;
            tka.To = new System.Windows.Thickness(525 - 100 - 3, btn.Margin.Top, 0, 0);
            tka.Duration = TimeSpan.FromSeconds(0.6);
            tka.AccelerationRatio = 0.2;
            tka.DecelerationRatio = 0.8;
            bdr.BeginAnimation(Button.MarginProperty, tka);
        }

        static public void MarginShowOff(Button btn, Border bdr)
        {
            ThicknessAnimation tka = new ThicknessAnimation();
            tka.From = btn.Margin;
            tka.To = new System.Windows.Thickness(525 - 46, btn.Margin.Top, 0, 0);
            tka.Duration = TimeSpan.FromSeconds(0.6);
            tka.AccelerationRatio = 0.2;
            tka.DecelerationRatio = 0.8;
            btn.BeginAnimation(Button.MarginProperty, tka);

            tka = new ThicknessAnimation();
            tka.From = bdr.Margin;
            tka.To = new System.Windows.Thickness(525 - 4, btn.Margin.Top, 0, 0);
            tka.Duration = TimeSpan.FromSeconds(0.6);
            tka.AccelerationRatio = 0.2;
            tka.DecelerationRatio = 0.8;
            bdr.BeginAnimation(Button.MarginProperty, tka);
        }
    }
}
