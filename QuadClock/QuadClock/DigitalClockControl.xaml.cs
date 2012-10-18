using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace QuadClock
{
    public sealed partial class DigitalClockControl : UserControl
    {
        public DigitalClockControl()
        {
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
            //var formatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longtime");
            //DateTime dateToFormat = DateTime.Now;
            //TimeTxt.Text = formatter.Format(dateToFormat); 
            //TimeTxt.Text = DateTime.Now.ToString("HH:mm:ss");

            //DateTime myTime = DateTime.Now;
            //TimeTxt.Text = myTime.ToLongTimeString();//ToString("t");

            var formatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("{hour.integer}:{minute.integer(2)}:{second.integer(2)}");
            DateTime dateToFormat = DateTime.Now;
            TimeTxt.Text = formatter.Format(dateToFormat);             
        }
    }
}
