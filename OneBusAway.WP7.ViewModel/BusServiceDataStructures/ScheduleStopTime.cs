﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Runtime.Serialization;

namespace OneBusAway.WP7.ViewModel.BusServiceDataStructures
{
    [DataContract()]
    public class ScheduleStopTime
    {
        [DataMember()]
        public DateTime arrivalTime { get; set; }

        [DataMember()]
        public DateTime departureTime { get; set ;}

        [DataMember()]
        public string serviceId { get; set; }

        [DataMember()]
        public string tripId { get; set; }
    }
}
