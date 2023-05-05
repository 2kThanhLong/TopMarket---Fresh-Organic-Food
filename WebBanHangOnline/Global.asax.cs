using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebBanHangOnline
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["ToDay"] = 0;
            Application["Yesterday"] = 0;
            Application["ThisWeek"] = 0;
            Application["LastWeek"] = 0;
            Application["ThisMonth"] = 0;
            Application["LastMonth"] = 0;
            Application["AllTheTime"] = 0;
            Application["visitors_online"] = 0;
        }
        void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 150;
            Application.Lock();
            Application["visitors_online"] = Convert.ToInt32(Application["visitors_online"]) + 1;
            Application.UnLock();
            try
            {
                var item = WebBanHangOnline.Models.Common.StatisticalAccess.ThongKe();
                if (item!=null)
                {
                    Application["ToDay"] = long.Parse("0" + item.HomNay.ToString("#,###"));
                    Application["Yesterday"] = long.Parse("0" + item.HomQua.ToString("#,###"));
                    Application["ThisWeek"] = long.Parse("0" + item.ThangNay.ToString("#,###"));
                    Application["LastWeek"] = long.Parse("0" + item.ThangTruoc.ToString("#,###"));
                    Application["ThisMonth"] = long.Parse("0" + item.ThangNay.ToString("#,###"));
                    Application["LastMonth"] = long.Parse("0" + item.ThangTruoc.ToString("#,###"));
                    Application["AllTheTime"] = (int.Parse(item.TatCa.ToString())).ToString("#,###");
                }
               
            }
            catch { }

        }
        void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["visitors_online"] = Convert.ToUInt32(Application["visitors_online"]) - 1;
            Application.UnLock();
        }
    }
}
