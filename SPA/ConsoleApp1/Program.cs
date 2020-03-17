using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPACalculator;
using static SPACalculator.SPACalculator;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();
            var dic = new Dictionary<DateTime, Data>();
            SPAData data = new SPAData
            {
                Year = 2020,
                Month = 1,
                Day = 1,
                Hour = 1,
                Minute = 0,
                Second = 0,
                DeltaUt1 = 0,
                DeltaT = 0,
                Timezone = 2,
                Latitude = 54.5421,
                Longitude = 23.57262,
                Elevation = 76,
                Pressure = 993,
                Temperature = 20,
                Slope = 0,
                AzmRotation = 0,
                AtmosRefract = 0.5667,
            };

            var endTime = new DateTime(2021, 1, 1, 1, 1, 1);
            for (var time = new DateTime(2020, 1, 1, 1, 1, 1); time < endTime; time = time.AddMinutes(1.0))
            {
                data.Month = time.Month;
                data.Day = time.Day;
                data.Hour = time.Hour;
                data.Minute = time.Minute;
                SPACalculate(ref data);
                dic.Add(time, new Data { Azimuth = data.Azimuth, Zenith = data.Zenith });
            }
            timer.Stop();




            
        }
    }

    public class Data
    {
        public double Zenith { get; set; }
        public double Azimuth { get; set; }
    }
}


