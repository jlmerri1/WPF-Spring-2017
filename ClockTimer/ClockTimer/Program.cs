using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClockTimer
{

    public class TimeInfoEventArgs : EventArgs
    {
        public int hour;
        public int minute;
        public int second;

        public TimeInfoEventArgs(int h, int m, int s)
        {
            this.hour = h;
            this.minute = m;
            this.second = s;
        }
    }

    public class Clock
    {
        private int hour;
        private int minute;
        private int second;
        
        public delegate void SecondChangedHandler(object clock, TimeInfoEventArgs timeInformation);
        public SecondChangedHandler SecondChanged;

        public void Run()
        {
            for(;;)
            {
                Thread.Sleep(100);
                System.DateTime dt = System.DateTime.Now;

                if(dt.Second != second)
                {
                    TimeInfoEventArgs timeInformation = new TimeInfoEventArgs(dt.Hour, dt.Minute, dt.Second);
                    if(SecondChanged != null)
                    {
                        SecondChanged(this, timeInformation);
                    }
                }
                this.second = dt.Second;
                this.minute = dt.Minute;
                this.hour = dt.Hour;
            }
        }
    }

    public class DisplayClock
    {
        public void Subscribe(Clock theClock)
        {
            theClock.SecondChanged += new Clock.SecondChangedHandler(TimeHasChanged);
        }

        public void TimeHasChanged(object theClock, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Current Time: {0}:{1}:{2}", ti.hour.ToString(), ti.minute.ToString(), ti.second.ToString());
        }
    }

    public class LogCurrentTime
    {
        public void Subscribe(Clock theClock)
        {
            theClock.SecondChanged += new Clock.SecondChangedHandler(WriteLogEntry);
        }
        public void WriteLogEntry(object theClock, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Logging to file: {0}:{1}:{2}", ti.hour.ToString(), ti.minute.ToString(), ti.second.ToString());
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Clock theClock = new Clock();

            DisplayClock dc = new DisplayClock();
            dc.Subscribe(theClock);

            LogCurrentTime lc = new LogCurrentTime();
            lc.Subscribe(theClock);

            theClock.Run();
        }
    }
}
