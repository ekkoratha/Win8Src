using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace QuadClock
{
    public sealed partial class AnalogClockControl : UserControl
    {
        private DateTime _time = new DateTime(2000, 1, 1, 18, 15, 50);
        private double hour;
        private double minute;
        private double second;


        public double handThickness;
        public double minuteThickness;
        public double secondThickness;


        public static readonly DependencyProperty HoursProperty =
        DependencyProperty.Register("Hours", typeof(double), typeof(AnalogClockControl), new PropertyMetadata(null));

        public double Hours
        {
            set { SetValue(HoursProperty, value); }
            get { return (double)GetValue(HoursProperty); }
        }

        public AnalogClockControl()
        {
            handThickness = 4;
            minuteThickness = handThickness - 1;
            secondThickness = minuteThickness - 1;
            this.InitializeComponent();
            Loaded += new RoutedEventHandler(onLoad);
        }

        public void onLoad(object o, RoutedEventArgs e)
        {
            DispatcherTimer tmr = new DispatcherTimer();
            tmr.Interval = TimeSpan.FromSeconds(1);
            tmr.Tick += Draw;
            tmr.Start();
        }

        private void Draw(object sender, object e)
        {
            SetTime(DateTime.Now);
            ClockLayout.Children.Clear();

            double ClockWidth = ClockLayout.Width;

            var step = 360 / 60;
            var innerRadiusX = (ClockWidth * 0.8) / 2;
            var innerRadiusY = (Height * 0.8) / 2;

            var outerRadiusX = (ClockWidth * 0.9) / 2;
            var outerRadiusY = (Height * 0.9) / 2;

            var textRadiusX = (ClockWidth * 0.7) / 2;
            var textRadiusY = (Height * 0.7) / 2;

            outerCasing.Visibility = Visibility.Visible;
            ClockLayout.Children.Add(outerCasing);

            for (var i = 0; i < 60; i++)
            {
                Line line = new Line();
                if (i % 5 == 0)
                {
                    line.Stroke = new SolidColorBrush(Colors.Black);
                    line.X1 = (ClockWidth / 2) + Math.Sin((step * i) * (Math.PI / 180)) * innerRadiusX;
                    line.Y1 = (Height / 2) + Math.Cos((step * i) * (Math.PI / 180)) * innerRadiusY;
                    line.X2 = (ClockWidth / 2) + Math.Sin((step * i) * (Math.PI / 180)) * outerRadiusX;
                    line.Y2 = (Height / 2) + Math.Cos((step * i) * (Math.PI / 180)) * outerRadiusY;

                    var textblock = new TextBlock();
                    textblock.FontFamily = new FontFamily("verdana");
                    textblock.FontSize = 14;
                    SolidColorBrush mytextBrush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

                    textblock.Foreground = mytextBrush;
                    if (i % 15 == 0)
                        textblock.Text = i == 0 ? "12" : ((double)(i / 60D) * 12D).ToString();
                    else
                        textblock.Text = "";

                    var textX = (ClockWidth / 2) + Math.Sin(-((step * i + 180) % 360) * (Math.PI / 180)) * textRadiusX;
                    var textY = (Height / 2) + Math.Cos(-((step * i + 180) % 360) * (Math.PI / 180)) * textRadiusY;

                    textblock.SetValue(Canvas.LeftProperty, textX - textblock.ActualWidth / 2);
                    textblock.SetValue(Canvas.TopProperty, textY - textblock.ActualHeight / 2);

                    ClockLayout.Children.Add(textblock);
                }
                line.StrokeThickness = 4;
                ClockLayout.Children.Add(line);
            }

            DrawHourHand();
            DrawMinuteHand();
            DrawSecondHand();
        }

        private void DrawHourHand()
        {
            //Change hour value to percentage for use with 360
            double hourPercentage = (hour + (minute / 60D)) / 12D;

            //Get the Hour degree value
            double hourDegree = 360 * hourPercentage;
            double ClockWidth = ClockLayout.Width;
            //DrawHand(ClockWidth / 5.5D, Height / 5.5D, -hourDegree, Colors.Black, handThickness);
            DrawHand2(ClockWidth / 4.5D, Height / 4.5D, -hourDegree, Colors.Black, handThickness);
        }

        private void DrawMinuteHand()
        {
            //Change minute value to percentage for use with 360
            double minutePercentage = (minute + (second / 60D)) / 60;
            //Get the minute percentage
            double minuteDegree = 360 * minutePercentage;
            double ClockWidth = ClockLayout.Width;
            // DrawHand(ClockWidth / 4.5D, Height / 4.5D, -minuteDegree, Colors.Blue, minuteThickness);
            // DrawHand2(ClockWidth / 3.5D, Height / 3.5D, -minuteDegree, Colors.Blue, minuteThickness);
            DrawHand2(ClockWidth / 2.8D, Height / 2.8D, -minuteDegree, Colors.Black, minuteThickness);
        }

        private void DrawSecondHand()
        {
            double secondPercentage = second / 60D;
            //Get the minute percentage
            double secondDegree = 360 * secondPercentage;
            double ClockWidth = ClockLayout.Width;
            //DrawHand2(ClockWidth / 3.5D, Height / 3.5D, -secondDegree, Colors.Red, secondThickness);
            DrawHand2(ClockWidth / 2.7D, Height / 2.7D, -secondDegree, Colors.Red, secondThickness);
        }

        private void DrawHand(double radiusX, double radiusY, double angle, Color color, double thickness)
        {
            double ClockWidth = ClockLayout.Width;

            var hand = new Line
            {
                Stroke = new SolidColorBrush(color),
                X1 = ClockWidth / 2,
                Y1 = Height / 2,
                X2 = (ClockWidth / 2) + -Math.Sin(angle * (Math.PI / 180)) * radiusX,
                Y2 = (Height / 2) + -Math.Cos(angle * (Math.PI / 180)) * radiusY
            };
            hand.StrokeThickness = thickness;

            ClockLayout.Children.Add(hand);
        }
        private void DrawHand2(double radiusX, double radiusY, double angle, Color color, double thickness)
        {
            double ClockWidth = ClockLayout.Width;

            var hand = new Line
            {
                Stroke = new SolidColorBrush(color),
                X1 = ClockWidth / 2 + Math.Sin(angle * (Math.PI / 180)) * 12,
                Y1 = Height / 2 + Math.Cos(angle * (Math.PI / 180)) * 12,
                X2 = (ClockWidth / 2) + -Math.Sin(angle * (Math.PI / 180)) * radiusX,
                Y2 = (Height / 2) + -Math.Cos(angle * (Math.PI / 180)) * radiusY
            };
            hand.StrokeThickness = thickness;

            ClockLayout.Children.Add(hand);
        }
        #region IClockView Members

        public void SetTime(DateTime time)
        {
            _time = time.AddHours(Hours);

            //_time;
            hour = _time.Hour;
            minute = _time.Minute;
            second = _time.Second;

            // Draw;
        }

        #endregion
    }
}
