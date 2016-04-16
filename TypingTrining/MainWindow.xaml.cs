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
using BGSupport.FileSupport;
using TypingTrining.Animations;
using Microsoft.Win32;

namespace TypingTrining
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = "TypeTraining";
            FileCheck.CheckCreate();
            txtTextPreview.IsReadOnly = true;

            //txtFilePath.Text = @"C:\Users\Dell-\Desktop\新建文本文档.txt";

            txtTextPreview.Opacity = 0;
            lblWordChangedWarning.Opacity = 0;
            btnMore.Content = "<<<";
            lblChoose.Opacity = 0;
            lblChoose.IsEnabled = false;
            gdStart.Opacity = 0;
            gdStart.IsEnabled = false;
            rbtModle_Line.IsChecked = true;
            //StartingGrid.ActualHeight = 328.66666666666669
            //StartingGrid.ActualWidth = 510.66666666666657
        }

        private void btnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            Items.isLoadNewFile_flag = true;
            Items.isPassageChoosed = false;
            gdStart.IsEnabled = false;
            gdStart_anim.OpacityShowDown(gdStart);

            try
            {
                lblState.Content = "读取中...";
                txtTextPreview_anim.OpactiyShowOff(txtTextPreview, lblChoose);
                lblState.Foreground = new SolidColorBrush(Colors.Yellow);

                Items.UsingFile = new FileReader(txtFilePath.Text);
                lblState.Content = "读取完成";
                lblState.Foreground = new SolidColorBrush(Colors.Green);

                lblChoose.IsEnabled = true;
                txtTextPreview.IsEnabled = true;
                txtTextPreview.Text = LoadFile.Load(txtFilePath.Text);
                txtTextPreview_anim.OpacityShowUp(txtTextPreview, lblChoose);
            }
            catch
            {
                lblState.Content = "读取错误";
                lblState.Foreground = new SolidColorBrush(Colors.Red);
                Items.UsingFile = null;
                lblChoose.IsEnabled = false;
                txtTextPreview.IsEnabled = false;
                txtTextPreview_anim.OpactiyShowOff(txtTextPreview, lblChoose);
            }
        }

        private void btnMore_Click(object sender, RoutedEventArgs e)
        {
            if(!Items.isShowMore)
            {
                btnMore_anim.MarginShowUp(btnMore, bdrMore);
                Items.isShowMore = true;
                this.btnMore.Content = ">>>";
            }
            else
            {
                btnMore_anim.MarginShowOff(btnMore, bdrMore);
                Items.isShowMore = false;
                this.btnMore.Content = "<<<";
            }
        }

        private void txtTextPreview_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Items.isLoadNewFile_flag)
            {
                Items.isLoadNewFile_flag = false;
                Animations.lblWordChangedWarning_anim.OpaciytShow(lblWordChangedWarning);
            }
        }

        private void lblChoose_MouseEnter(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void lblChoose_MouseLeave(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void lblChoose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gdStart_anim.OpacityShowUp(gdStart);
            gdStart.IsEnabled = true;
            txtTextPreview.IsEnabled = false;
            Items.isPassageChoosed = true;
            //Items.writingString = CreateTempFile.Create(txtTextPreview.Text);
            //Items.fileLength = CreateTempFile.stringLength;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (rbtModle_Line.IsChecked == true)
            {
                LineModle_Start page = new LineModle_Start();
                page.totalBytes = ReadFileSize.Read(txtTextPreview.Text);

                this.Content = page;
            }
            else
            {

            }
        }

        private void BtnShowFileDialog_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == true)
                txtFilePath.Text = op.FileName;
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
