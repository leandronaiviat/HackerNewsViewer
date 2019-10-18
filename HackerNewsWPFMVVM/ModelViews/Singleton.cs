using HackerNewsWPFMVVM.Models.Api;

namespace HackerNewsWPFMVVM.ModelViews
{
    static class Singleton
    {
        public static HackerNewsEndPoint EndPoint { get; set; }

        static Singleton()
        {
            EndPoint = new HackerNewsEndPoint();            
        }
    }
}
