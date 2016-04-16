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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TypingTrining.Animations;
using BGSupport.FileSupport;
using AppFlags;
using System.Windows.Threading;
using TypingTrining.Animations;
using BGSupport.UserRecord;
using Model_TP_AC33;

namespace TypingTrining
{
    /// <summary>
    /// LineModle_Start.xaml 的交互逻辑
    /// </summary>
    public partial class LineModle_Start : Page
    {
        public LineModle_Start()
        {
            InitializeComponent();
        }

        int wroteBytes = 0;
        public int totalBytes;
        bool isBegin = false;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lblComplete.Opacity = 0;
            lblSpeed.Opacity = 0;
            lblTime.Opacity = 0;

            PgbProcess.Maximum = totalBytes;
            txtTrainingText.IsReadOnly = true;
            txtUserInput.Focus();

            string strFirstRead = Items.UsingFile.ReadNextLine().Trim();
            if (strFirstRead == Flag.FileLoadCompleteFlag)
                MessageBox.Show("此文件为空！", "操他娘狗日的");
            else if (strFirstRead == Flag.FileErrorFlag)
                MessageBox.Show("文件读取错误!", "操他娘狗日的");
            else
                txtTrainingText.Text = strFirstRead;
            //txtTrainingText.Text =str
        }

        DispatcherTimer timer = new DispatcherTimer();

        private void txtUserInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtTrainingText.Background = new SolidColorBrush(Colors.White);
            txtTrainingText.Foreground = new SolidColorBrush(Colors.Black);
            this.PgbProcess.Value = wroteBytes + txtUserInput.Text.Length;
            this.lblProcess.Content = wroteBytes + txtUserInput.Text.Length + "/" + totalBytes;
            if (!isBegin)
            {
                isBegin = true;
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += Timer_Tick;
                timer.IsEnabled = true;
            }
            if (txtTrainingText.Text.IndexOf(txtUserInput.Text) != 0)
            {
                txtTrainingText.Background = new SolidColorBrush(Colors.LightPink);
                txtTrainingText.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (txtTrainingText.Text == txtUserInput.Text)
            {
                wroteBytes = wroteBytes + txtTrainingText.Text.Length;

                string strFirstRead = Items.UsingFile.ReadNextLine().Trim();
                if (strFirstRead == Flag.FileLoadCompleteFlag)
                {
                    txtTrainingText.IsEnabled = false;
                    txtUserInput.IsEnabled = false;
                    lblTime.Content = usedSeconds + " seconds";
                    lblSpeed.Content = (int)totalBytes / usedSeconds * 60 + " character/min";
                    TypeComplete.OpacityShow(lblComplete, lblTime, lblSpeed);
                    Items.UsingFile.CloseFile();
                    try
                    {
                        Record_mod mod = new Record_mod();
                        mod.Length = totalBytes;
                        mod.RecordTime = DateTime.Now;
                        mod.Speed = (int)totalBytes / usedSeconds * 60;
                        ReadWriteRecord.InsertRecord(mod);
                    }
                    catch
                    {
                        MessageBox.Show("记录时出现错误");
                    }
                }
                else if (strFirstRead == Flag.FileErrorFlag)
                    MessageBox.Show("文件读取错误!", "操他娘狗日的");
                else
                    txtTrainingText.Text = strFirstRead;
                txtUserInput.Text = "";
            }
        }

        int usedSeconds = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            usedSeconds++;
            lblUsedTime.Content = "已用时间：" + usedSeconds;
            
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }

        bool isPuasedFlag = false;

        private void btnPuase_Click(object sender, RoutedEventArgs e)
        {
            if (!isPuasedFlag)
            {
                isPuasedFlag = true;
                btnPuase.Content = "继续";
                this.txtTrainingText.IsEnabled = false;
                this.txtUserInput.IsEnabled = false;
                timer.IsEnabled = false;
            }
            else
            {
                isPuasedFlag = false;
                btnPuase.Content = "暂停";
                this.txtTrainingText.IsEnabled = true;
                this.txtUserInput.IsEnabled = true;
                timer.IsEnabled = true;
                txtUserInput.Focus();
            }
        }

        private void lblRecords_MouseEnter(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void lblRecords_MouseLeave(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void lblRecords_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RecordWindow rw = new RecordWindow();
            rw.Show();
        }
    }
}
