using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Solitas.Annotations;

namespace Solitas
{
    public class ClockTicker2 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DateTime DateTime => DateTime.Now;

        public ClockTicker2()
        {
            var timer = new DispatcherTimer();
            timer.Tick += (o, e) =>
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateTime"));
            };
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }
    }
}
