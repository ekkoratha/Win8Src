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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace QuadClock
{
    public sealed partial class BinaryDigitalControl : UserControl
    {
        internal static Uri _baseUri = new Uri("ms-appx:///");
        BitmapImage b0 = new BitmapImage();
        BitmapImage b1 = new BitmapImage();
        DateTime _time;

        public BinaryDigitalControl()
        {
            this.InitializeComponent();
            //b0.UriSource = new Uri(@"PNG/yellow_light.png", UriKind.Relative);
            //b1.UriSource = new Uri(@"PNG/green_light.png", UriKind.Relative);
            
            b0.UriSource = new Uri(_baseUri, @"PNG/yellow_light.png");//new Uri(@"PNG/yellow_light.png", UriKind.Relative);
            b1.UriSource = new Uri(_baseUri, @"PNG/green_light.png");//new Uri(@"PNG/green_light.png", UriKind.Relative);

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
          
            _time = DateTime.Now;
            DrawHour();
            DrawMinute();
            DrawSecond();
        }


        public void DrawHour()
        {
            //0000 =0
            //0001 =1
            //0010 =2
            //0011 =3
            //0100 =4
            //0101 =5
            //0110 =6
            //0111 =7
            //1000 =8
            //1001 =9

            /*
             *      h03
             *      h02
             * h11  h01
             * h10  h00
             */
            h11.Source = b0;
            h10.Source = b0;
            h00.Source = b0;
            h01.Source = b0;
            h02.Source = b0;
            h03.Source = b0;
            int Hour1 = _time.Hour % 10;
            switch (Hour1)
            {
                case 1: h00.Source = b1; break;
                case 2: h01.Source = b1; break;
                case 3: h00.Source = b1; h01.Source = b1; break;
                case 4: h02.Source = b1; break;
                case 5: h02.Source = b1; h00.Source = b1; break;
                case 6: h02.Source = b1; h01.Source = b1; break;
                case 7: h02.Source = b1; h01.Source = b1; h00.Source = b1; break;
                case 8: h03.Source = b1; break;
                case 9: h03.Source = b1; h00.Source = b1; break;
            }

            int Hour2 = _time.Hour / 10;
            switch (Hour2)
            {
                case 1: h10.Source = b1; break;
                case 2: h11.Source = b1; break;
            }
        }

        public void DrawMinute()
        {
            //0000 =0
            //0001 =1
            //0010 =2
            //0011 =3
            //0100 =4
            //0101 =5
            //0110 =6
            //0111 =7
            //1000 =8
            //1001 =9

            /*
             *      m03
             * m12  m02
             * m11  m01
             * m10  m00
             */
            m12.Source = b0;
            m11.Source = b0;
            m10.Source = b0;
            m00.Source = b0;
            m01.Source = b0;
            m02.Source = b0;
            m03.Source = b0;
            int min1 = _time.Minute % 10;
            switch (min1)
            {
                case 1: m00.Source = b1; break;
                case 2: m01.Source = b1; break;
                case 3: m00.Source = b1; m01.Source = b1; break;
                case 4: m02.Source = b1; break;
                case 5: m02.Source = b1; m00.Source = b1; break;
                case 6: m02.Source = b1; m01.Source = b1; break;
                case 7: m02.Source = b1; m01.Source = b1; m00.Source = b1; break;
                case 8: m03.Source = b1; break;
                case 9: m03.Source = b1; m00.Source = b1; break;
            }

            int min2 = _time.Minute / 10;
            switch (min2)
            {
                case 1: m10.Source = b1; break;
                case 2: m11.Source = b1; break;
                case 3: m10.Source = b1; m11.Source = b1; break;
                case 4: m12.Source = b1; break;
                case 5: m12.Source = b1; m10.Source = b1; break;
            }
        }

        public void DrawSecond()
        {
            //0000 =0
            //0001 =1
            //0010 =2
            //0011 =3
            //0100 =4
            //0101 =5
            //0110 =6
            //0111 =7
            //1000 =8
            //1001 =9

            /*
             *      m03
             * m12  m02
             * m11  m01
             * m10  m00
             */
            s12.Source = b0;
            s11.Source = b0;
            s10.Source = b0;
            s00.Source = b0;
            s01.Source = b0;
            s02.Source = b0;
            s03.Source = b0;
            int sec1 = _time.Second % 10;
            switch (sec1)
            {
                case 1: s00.Source = b1; break;
                case 2: s01.Source = b1; break;
                case 3: s00.Source = b1; s01.Source = b1; break;
                case 4: s02.Source = b1; break;
                case 5: s02.Source = b1; s00.Source = b1; break;
                case 6: s02.Source = b1; s01.Source = b1; break;
                case 7: s02.Source = b1; s01.Source = b1; s00.Source = b1; break;
                case 8: s03.Source = b1; break;
                case 9: s03.Source = b1; s00.Source = b1; break;
            }

            int min2 = _time.Second / 10;
            switch (min2)
            {
                case 1: s10.Source = b1; break;
                case 2: s11.Source = b1; break;
                case 3: s10.Source = b1; s11.Source = b1; break;
                case 4: s12.Source = b1; break;
                case 5: s12.Source = b1; s10.Source = b1; break;
            }
        }
    }
}
