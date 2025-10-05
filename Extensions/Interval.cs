﻿using System.Diagnostics;

namespace SimpleBot.Extensions
{
    public class Interval
    {
        private readonly Stopwatch _stopwatch;
        private readonly int _msInterval;

        public Interval(int milliseconds)
        {
            _stopwatch = Stopwatch.StartNew();
            _msInterval = milliseconds;
        }

        public Interval(TimeSpan timespan)
            : this((int)timespan.TotalMilliseconds)
        {
        }

        public bool Elapsed
        {
            get
            {
                if (_stopwatch.ElapsedMilliseconds >= _msInterval)
                {
                    _stopwatch.Restart();
                    return true;
                }
                return false;
            }
        }
    }
}
