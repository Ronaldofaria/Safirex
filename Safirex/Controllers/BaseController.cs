using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Safirex.Controllers
{

    public abstract partial class BaseController : Controller
    {
        public SafirexContext db = new SafirexContext();

        public BaseController()
        {
            // save url current
            if ((System.Web.HttpRequestWrapper) Request != null)
            {
                ViewBag.urlVoltar = ((System.Web.HttpRequestWrapper)Request).UrlReferrer;
                ViewBag.urlVoltar = Regex.Replace(ViewBag.urlVoltar.ToString(), "href=\"([^ \"]*)", "href=\"" + ViewBag.urlVoltar);
            }
        }

        public String ErrorMessage
        {   // show messagem screen by user 
            get { return TempData["ErrorMessage"] == null ? String.Empty : TempData["ErrorMessage"].ToString(); }
            set { TempData["ErrorMessage"] = value; }
        }

        public ActionResult ScreenSize()
        {
            // save url link
            ViewBag.urlReturn = ((System.Web.HttpRequestWrapper)Request).UrlReferrer;
            ViewBag.urlReturn = Regex.Replace(ViewBag.urlReturn.ToString(), "href=\"([^ \"]*)", "href=\"" + ViewBag.urlReturn);
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
            return Redirect(ViewBag.urlReturn);
        }

    }

}


    