using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrilliantIdea.Web.Controllers
{
    public class SettingsController : Controller
    {
        //
        // GET: /Settings/

        public ActionResult HomeSettings()
        {
            return PartialView("HomeSettings");
        }

    }
}
