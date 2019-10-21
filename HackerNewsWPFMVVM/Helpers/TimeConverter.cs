using System;

namespace HackerNewsWPFMVVM.Helpers
{
    public class TimeConverter
    {
        public static string TimeSpanToString(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var postTime = origin.AddSeconds(timestamp);

            var time = DateTime.Now.AddHours(3).Subtract(postTime);

            if (time.TotalSeconds < 60)
            {
                var result = Math.Floor(time.TotalSeconds).ToString();
                return result == "1" ? result + " second ago" : result + " seconds ago";
            }

            if (time.TotalHours < 1)
            {
                var result = Math.Floor(time.TotalMinutes).ToString();
                return result == "1" ? result + " minute ago" : result + " minutes ago";
            }

            if (time.TotalDays < 1)
            {
                var result = Math.Floor(time.TotalHours).ToString();
                return result == "1" ? result + " hour ago" : result + " hours ago";
            }

            if (time.TotalDays <= 30)
            {
                var result = Math.Floor(time.TotalDays).ToString();
                return result == "1" ? result + " day ago" : result + " days ago";
            }

            if (time.TotalDays > 30 && time.TotalDays <= 365)
            {
                var result = Math.Floor(time.TotalDays / 30).ToString();
                return result == "1" ? result + " month ago" : result + " months ago";
            }
            
            return "on " + postTime.Date.ToString("dddd, dd MMMM yyyy");
        }
    }
}
