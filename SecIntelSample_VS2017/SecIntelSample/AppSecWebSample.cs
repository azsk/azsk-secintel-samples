using System.IO;
using System.Web.Mvc;
using System.Xml;

namespace SecIntelSample
{
    public class AppSecWebSample : Controller
    {
        public RedirectResult RedirectSample(string url)
        {
            // appsec_mvc_open_redirect
            // This is work under progress. Will start flagging soon
            return Redirect(url);
        }
    }
}