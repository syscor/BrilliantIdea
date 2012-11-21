using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrilliantIdea.WebApp.Models.Trees;

namespace BrilliantIdea.WebApp.Controllers
{
    public class ProcessController : Controller
    {
        //
        // GET: /Process/

        public ActionResult ProcessView()
        {
            return View();
        }

        public ActionResult GetTree()
        {
            var tree = new List<Node>();

            return Json(tree, JsonRequestBehavior.AllowGet);
        }
    }
}
