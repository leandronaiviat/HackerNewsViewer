using System.Web;

namespace HackerNewsWPFMVVM.ModelViews
{
    public class CommentsParser
    {
        public static string Parse(string text)
        {
            if (text != null)
            {
                string newText = text.Replace("<p>", "\n<p>");
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(newText);
                newText = HttpUtility.HtmlDecode(doc.DocumentNode.InnerText);
                newText.Replace("\n", System.Environment.NewLine + "&amp;#10;&amp;#10;");
                return newText;
            }
            return null;
        }
    }
}
