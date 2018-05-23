using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecIntelSample.WebForms
{
    public partial class Sample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void FormsAuthSample()
        {
            // appsec_web_formsauthticket_timeout
            var ticket = new FormsAuthenticationTicket(
                1,
                "User1",
                DateTime.Now,
                DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                false,
                "user,user1",
                FormsAuthentication.FormsCookiePath);
        }

        public void CookieSample()
        {
            // appsec_web_cookie_combo_one
            // appsec_web_cookie_combo_two
            var cookie = new HttpCookie("Auth", "Ok");

            // appsec_web_cookie_secure

            cookie.Secure = true;

            // appsec_web_cookie_httponly

            cookie.HttpOnly = true;

            // appsec_web_cookie_expires

            cookie.Expires = DateTime.Now.AddDays(5);
        }

        public void RequestValidation()
        {
            // appsec_web_requestvalidation

            var pagesSection = ConfigurationManager.GetSection("system.web/pages") as PagesSection;
            pagesSection.ValidateRequest = false;
        }
    }
}