﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork20200601_MVVM.Mode
{
    public class CurrentConditions
    {

      
            public DateTime LocalObservationDateTime { get; set; }
            public int EpochTime { get; set; }
            public string WeatherText { get; set; }
            public int WeatherIcon { get; set; }
            public bool HasPrecipitation { get; set; }
            public object PrecipitationType { get; set; }
            public bool IsDayTime { get; set; }
            public Temperature Temperature { get; set; }
            public string MobileLink { get; set; }
            public string Link { get; set; }
        }

        public class Temperature
        {
            public Units Metric { get; set; }
            public Units Imperial { get; set; }
        }

    //Змінюємо назву класу з Metric в Unit Units
        public class Units
        {
            public float Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

    //Видалили один клас
        //public class Imperial
        //{
        //    public int Value { get; set; }
        //    public string Unit { get; set; }
        //    public int UnitType { get; set; }
        //}

    
}
