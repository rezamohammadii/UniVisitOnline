﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitOnline.Controllers
{
    public class PanelController : Controller
    {

        public IActionResult DocDashboard()
        {
            return View();
        }
    }
}
