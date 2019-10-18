using HackerNewsWPFMVVM.Models.Api;
using HackerNewsWPFMVVM.ModelViews.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerNewsWPFMVVM.ModelViews
{
    static class Singleton
    {
        public static HackerNewsEndPoint EndPoint { get; set; }
        public static IsLoadingNotifyer Notifyer { get; set; }
        public static BackgroudConverter Converter { get; set; }

        static Singleton()
        {
            EndPoint = new HackerNewsEndPoint();
            Notifyer = new IsLoadingNotifyer();
            Converter = new BackgroudConverter();
            
        }

        public static HackerNewsEndPoint GetEndPoint()
        {
            return EndPoint;
        }
    }
}
