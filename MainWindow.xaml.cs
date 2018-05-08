using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BmiWpfDemo
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 身高拉桿 
        private void HeightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsInitialized)
            {
                // 更新數值
                HeightNumber.Text = HeightSlider.Value.ToString();

                // 計算拉桿數值轉為 0 ~ 1
                double heightWeight = (HeightSlider.Value - HeightSlider.Minimum) / (HeightSlider.Maximum - HeightSlider.Minimum);

                // 計算要移動的範圍
                double range = HeightSlider.ActualWidth - HeightRect.ActualWidth;

                // 移動數字框
                Canvas.SetLeft(HeightRect, heightWeight * range);


                // 計算 BMI
                double bmi = WeightSlider.Value / Math.Pow(HeightSlider.Value / 100, 2);

                // 用小數點當區隔拆開
                string[] parts = Math.Round(bmi, 1).ToString().Split('.');

                // 顯示 BMI
                BmiNumber1.Text = parts[0];
                if (parts.Length > 1)
                {
                    BmiNumber2.Text = '.' + parts[1];
                }

                // 變更文字
                if (bmi < 18.5)
                {
                    ResultText.Text = "Your are too thin, Put on some weight!";
                    ResultText.Foreground = Brushes.Red;
                }
                else if (bmi >= 18.5 && bmi < 24)
                {
                    ResultText.Text = "You have a normal body weight. Great Job!";
                    ResultText.Foreground = Brushes.LimeGreen;
                }
                else
                {
                    ResultText.Text = "Your are too fat!, Try to lose weight now!";
                    ResultText.Foreground = Brushes.Red;
                }
            }
        }

        // 體重拉桿
        private void WeightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsInitialized)
            {
                // 更新數值
                WeightNumber.Text = WeightSlider.Value.ToString();

                // 計算拉桿數值轉為 0 ~ 1
                double weightWeight = (WeightSlider.Value - WeightSlider.Minimum) / (WeightSlider.Maximum - WeightSlider.Minimum);

                // 計算要移動的範圍
                double range = WeightSlider.ActualWidth - WeightRect.ActualWidth;

                // 移動數字框
                Canvas.SetLeft(WeightRect, weightWeight * range);


                // 計算 BMI
                double bmi = WeightSlider.Value / Math.Pow(HeightSlider.Value / 100, 2);

                // 用小數點當區隔拆開
                string[] parts = Math.Round(bmi, 1).ToString().Split('.');

                // 顯示 BMI
                BmiNumber1.Text = parts[0];
                if (parts.Length > 1)
                {
                    BmiNumber2.Text = '.' + parts[1];
                }

                // 變更文字
                if (bmi < 18.5)
                {
                    ResultText.Text = "Your are too thin, Put on some weight!";
                    ResultText.Foreground = Brushes.Red;
                }
                else if (bmi >= 18.5 && bmi < 24)
                {
                    ResultText.Text = "You have a normal body weight. Great Job!";
                    ResultText.Foreground = Brushes.LimeGreen;
                }
                else
                {
                    ResultText.Text = "Your are too fat!, Try to lose weight now!";
                    ResultText.Foreground = Brushes.Red;
                }
            }
        }



        // 移動視窗 
        private void BaseGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        // 關閉視窗 
        private void CloseBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        // 重置按鈕 
        private void ResetBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HeightSlider.Value = HeightSlider.Minimum;
            WeightSlider.Value = WeightSlider.Minimum;
        }
    }
}
