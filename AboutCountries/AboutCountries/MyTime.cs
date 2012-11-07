using System;
using Windows.UI.Xaml;
namespace AboutCountries
{
    public class MyTime
    {
        public DateTime _time;
        public MyTime()
        {
        }

        public void init()
        {
            DispatcherTimer tmr = new DispatcherTimer();
            tmr.Interval = TimeSpan.FromSeconds(1);
            tmr.Tick += Draw;
            tmr.Start();
        }

        private void Draw(object sender, object e)
        {
           _time= DateTime.UtcNow;
        }
    }
}
