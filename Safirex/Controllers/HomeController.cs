using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safirex.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Viewp()
        {
            return View();
        }

        public ActionResult Login(string MessageErro, string MessageInfo)
        {
            ViewBag.MessageErro = MessageErro;
            ViewBag.MessageInfo = MessageInfo;

            return View();
        }

        [HttpPost]
        public ActionResult Login(string userLogin, string userPassword, string MessageErro, string MessageInfo)
        {
            ViewBag.MessageInfo = "Usuario Logado com sucesso.";
            // tem validar o usuario e os acessos ao sistema neste controle.

            return View("Index");
        }
    
        public ActionResult Index()
        {
            Session["urlVolta"] = ((System.Web.HttpRequestWrapper)Request).RawUrl;
            if (Session["screenSize"] == null)
            {
                Session["screenSize"] = "container body-content;";
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}