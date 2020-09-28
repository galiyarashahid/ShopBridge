using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBridge.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult New()
        {
            return View();
        }

        public ActionResult ItemDetail(int id)
        {
            return View();
        }
    }
}