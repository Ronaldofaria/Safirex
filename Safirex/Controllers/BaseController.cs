using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace Safirex.Controllers
{

    public class BaseController : Controller
    {
        public SafirexContext db = new SafirexContext();

    }

}


    