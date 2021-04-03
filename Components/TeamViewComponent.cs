using Assignment10.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;
        public TeamViewComponent (BowlingLeagueContext cont)
        {
            context = cont;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedName = RouteData?.Values["teamname"];

            return View(context.Teams
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
