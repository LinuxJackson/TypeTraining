using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BGSupport.UserRecord;
using Model_TP_AC33;

namespace TypingTrining
{
    /// <summary>
    /// RecordWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RecordWindow : Window
    {
        public RecordWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] records = ReadWriteRecord.ReadRecord.Read();

                int height = 0;

                foreach (string s in records)
                {
                    if (s == "")
                        continue;
                    height = height + 27;
                    skpRecord.Height = height;
                    Grid gd = new Grid();
                    gd.Width = skpRecord.Width;
                    gd.Height = 27;
                    gd.MouseEnter += Gd_MouseEnter;
                    gd.MouseLeave += Gd_MouseLeave;
                    gd.MouseDown += Gd_MouseDown;

                    string[] arr = s.Split(',');

                    Label lblDateTime = new Label();
                    lblDateTime.Content = arr[0];
                    lblDateTime.Margin = new Thickness(0, 0, 0, 0);
                    Label lblLength = new Label();
                    lblLength.Content = arr[1] + "字";
                    lblLength.Margin = new Thickness(110, 0, 0, 0);
                    Label lblSpeed = new Label();
                    lblSpeed.Content = arr[2] + "字/分钟";
                    lblSpeed.Margin = new Thickness(180, 0, 0, 0);

                    gd.Children.Add(lblDateTime);
                    gd.Children.Add(lblLength);
                    gd.Children.Add(lblSpeed);

                    skpRecord.Children.Add(gd);
                }
            }
            catch
            {
                MessageBox.Show("数据处理异常，请再试一次");
            }
        }

        private void Gd_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Gd_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid gd = (Grid)sender;
            gd.Background = new SolidColorBrush(Colors.White);
        }

        private void Gd_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid gd = (Grid)sender;
            gd.Background = new SolidColorBrush(Colors.AliceBlue);
        }
    }
}
