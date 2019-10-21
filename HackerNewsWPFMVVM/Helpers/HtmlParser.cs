using System.Web;

namespace HackerNewsWPFMVVM.ModelViews
{
    public class HtmlParser
    {
        public static string Parse(string text)
        {
            if (text != null)
            {
                string newText = text.Replace("<p>", "\n\n<p>");
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(newText);
                newText = HttpUtility.HtmlDecode(doc.DocumentNode.InnerText);
                return newText;
            }
            return null;
        }
    }
}
