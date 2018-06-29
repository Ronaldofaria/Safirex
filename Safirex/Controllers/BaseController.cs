using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Safirex.CachingObjects;
using Safirex.Controllers;

namespace Safirex.Controllers
{

    public abstract partial class BaseController : Controller
    {
        private const string V = "xx";
        public SafirexContext db = new SafirexContext();
        public List<string> urlLista = new List<string>();

        public BaseController()
        {
            // save url current
        }

        public ActionResult RedirectToPrevious()
        {

            // fetch from the cache:
            List<UrlListed> listaURL = GlobalCachingProvider.Instance.GetItem("listaURL") as List<UrlListed>;
            
            // renoved list
            List<UrlListed> items = listaURL.Where(prop => !prop.UrlSingle.Contains(listaURL.ElementAt(listaURL.Count()-1).UrlSingle)).ToList();
            string urlReturn;

            // get last Url to retunr
            if (items.Count() > 0)
            {
               urlReturn = items.ElementAt(items.Count() - 1).UrlFullPath;
               List<UrlListed> items2 = items.Where(prop => !prop.UrlSingle.Contains(items.ElementAt(items.Count() - 1).UrlSingle)).ToList();
               //Store the message in the cache:
               GlobalCachingProvider.Instance.AddItem("listaURL", items2);
            }
            else
            {
               urlReturn = HttpContext.Request.Url.Scheme+"://"+HttpContext.Request.Url.Authority;
               //Store the message in the cache:
               GlobalCachingProvider.Instance.AddItem("listaURL", items);
            }
            return Redirect(urlReturn);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var httpContext = filterContext.HttpContext;

            if (httpContext.Request.RequestType == "GET"
                && !httpContext.Request.IsAjaxRequest()
                && filterContext.IsChildAction == false)    // do no overwrite if we do child action.
            {
                // restore request
                Uri CurUrl = ((Uri)httpContext.Request.Url);
                // restore cache
                List<UrlListed> listaURL = GlobalCachingProvider.Instance.GetItem("listaURL") as List<UrlListed> ?? new List<UrlListed>();
                if (listaURL != null)
                {
                    List<UrlListed> items = listaURL.Where(prop => !prop.UrlSingle.Contains(CurUrl.AbsolutePath.ToLower())).ToList();
                    UrlListed item = new UrlListed(CurUrl.AbsolutePath.ToLower(), CurUrl.PathAndQuery);
                    items.Add(item);
                    // saving in cache 
                    GlobalCachingProvider.Instance.AddItem("listaURL", items);
                }
            }
        }

        public class UrlListed
        {
            public UrlListed(string v1, string v2)
            {
                UrlSingle = v1;
                UrlFullPath = v2;
            }

            public string UrlSingle { get; set; }
            public string UrlFullPath { get; set; }
        }

        public String ErrorMessage
        {   // show messagem screen by user 
            get { return TempData["ErrorMessage"] == null ? String.Empty : TempData["ErrorMessage"].ToString(); }
            set { TempData["ErrorMessage"] = value; }
        }

        public ActionResult ScreenSize()
        {
            // get session in memory
            ViewBag.screenSize = Session["screenSize"];

            // atributte screeen full
            if (ViewBag.screenSize == "container-fluid body-content;")
            {
                Session["screenSize"] = "container body-content;";
                ViewBag.screenSize = Session["screenSize"];
            }
            else
            {
                // atributte screeen resize
                Session["screenSize"] = "container-fluid body-content;";
                ViewBag.screenSize = Session["screenSize"];
            }
            return RedirectToPrevious();

        }

    }
}


    