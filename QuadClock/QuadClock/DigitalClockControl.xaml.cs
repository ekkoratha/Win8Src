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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

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

            TimeTxt.Text = DateTime.Now.ToString("t");
        }
    }
}
