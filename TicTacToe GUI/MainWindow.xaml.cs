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
using System.Windows.Threading;

namespace TicTacToe_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int directionX = 1;
        int directionY = 1;
        private int hits = 0;

        private readonly DispatcherTimer _animationTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            _animationTimer.Interval = TimeSpan.FromMilliseconds(1);
            _animationTimer.Tick += PositionBall;
        }

        private void PositionBall(object? sender, EventArgs e)
        {
            var x = Canvas.GetLeft(Logo);
            if (x >= BallField.ActualWidth - Logo.ActualWidth) directionX = -1;
            if (x <= 0) directionX = 1;

            var y = Canvas.GetTop(Logo);
            if (y >= BallField.ActualHeight - Logo.ActualHeight) directionY = -1;
            if (y <= 0) directionY = 1;

            if (y <= 0 && x <= 0 || 
                y >= BallField.ActualHeight - Logo.ActualHeight && x >= BallField.ActualWidth - Logo.ActualWidth || 
                y >= BallField.ActualHeight - Logo.ActualHeight && x <= 0 || 
                y <= 0 && x >= BallField.ActualWidth - Logo.ActualWidth)
            {
                hits++;
                CounterLabel.Content = $"{hits} Hits";
            }

            Canvas.SetLeft(Logo, x + directionX);
            Canvas.SetTop(Logo, y + directionY);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_animationTimer.IsEnabled)
            {
                _animationTimer.Stop();
            }
            else
            {
                _animationTimer.Start();
            }

            var x = BallField.ActualWidth / 2;
            var y = BallField.ActualHeight / 2;

            Canvas.SetLeft(Logo, x);
            Canvas.SetTop(Logo, y);
        }
    }
}
