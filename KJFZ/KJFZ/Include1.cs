using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Encodings.Web;

namespace KJFZ
{
    public class Include1
    {

        public string intToHalfHour(IHtmlContent p1) //Konvertuje int u termine
        {
            string s1 = GetString(p1);
            int t1 = Int32.Parse(s1);
            int tmp1 = t1 / 2;
            int tmp2 = (t1 % 2)*30;
            string res = tmp1.ToString().PadLeft(2, '0') + ":" + tmp2.ToString().PadLeft(2, '0');
            return res;
        }

        public string intToHalfHour(String p1)
        {
            int t1 = Int32.Parse(p1);
            int tmp1 = t1 / 2;
            int tmp2 = (t1 % 2) * 30;
            string res = tmp1.ToString().PadLeft(2, '0') + ":" + tmp2.ToString().PadLeft(2, '0');
            return res;
        }

        public int HalfHourToInt(String p1) //Konvertuje termine u int
        {
            string tmp1 = p1.Substring(0, 2);
            string tmp2 = p1.Substring(3, 2);
            int i1 = Int32.Parse(tmp1) * 2;
            int i2 = Int32.Parse(tmp2) / 30;
            int res = i1 + i2;
            return res;
        }

        private static string GetString(IHtmlContent content) 
        {
            var writer = new System.IO.StringWriter();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }

    }
}
