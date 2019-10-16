using HackerNewsWPFMVVM.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerNewsWPFMVVM.ModelViews
{
    static class Singleton
    {
        public static HackerNewsEndPoint EndPoint { get; set; }

        static Singleton()
        {
            EndPoint = new HackerNewsEndPoint();
        }

        public static HackerNewsEndPoint GetEndPoint()
        {
            return EndPoint;
        }
    }
}
