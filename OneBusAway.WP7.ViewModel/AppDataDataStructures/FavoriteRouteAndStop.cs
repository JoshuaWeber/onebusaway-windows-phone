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
using OneBusAway.WP7.ViewModel.BusServiceDataStructures;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Device.Location;

namespace OneBusAway.WP7.ViewModel.AppDataDataStructures
{
    [DataContract()]
    public class FavoriteRouteAndStop
    {
        [DataMember]
        public Route route { get; set; }
        [DataMember]
        public RouteStops routeStops { get; set; }
        [DataMember]
        public Stop stop { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is FavoriteRouteAndStop)
            {
                FavoriteRouteAndStop otherFavorite = (FavoriteRouteAndStop)obj;
                if (
                    this.route == otherFavorite.route &&
                    this.stop == otherFavorite.stop &&
                    this.routeStops == otherFavorite.routeStops
                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("Favorite: Route='{0}', Stop='{1}', Direction{2}", route, stop, routeStops);
        }
    }

    public class FavoriteDistanceComparer : IComparer<FavoriteRouteAndStop>
    {
        private GeoCoordinate center;

        public FavoriteDistanceComparer(GeoCoordinate center)
        {
            this.center = center;
        }

        public int Compare(FavoriteRouteAndStop x, FavoriteRouteAndStop y)
        {
            int result = x.stop.location.GetDistanceTo(center).CompareTo(y.stop.location.GetDistanceTo(center));

            if (result == 0)
            {
                if (y.route == null)
                {
                    result = -1;
                }
                else if (x.route == null)
                {
                    result = 1;
                }
                else
                {
                    result = x.route.shortName.CompareTo(y.route.shortName);
                }
            }

            return result;
        }

    }
}