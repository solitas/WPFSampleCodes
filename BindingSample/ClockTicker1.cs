using System;
using System.Windows;
using System.Windows.Threading;

namespace Solitas
{
    public class ClockTicker1 : DependencyObject
    {
        public static DependencyProperty DateTimeProperty =
            DependencyProperty.Register("DateTime", typeof(DateTime), typeof(ClockTicker1));

        public DateTime DateTime
        {
            get => (DateTime) GetValue(DateTimeProperty);
            set => SetValue(DateTimeProperty, value);
        }

        public ClockTicker1()
        {
            var timer= new DispatcherTimer();
            timer.Tick += (o,e) => { DateTime = DateTime.Now; };
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }
    }
}
