using Assignment10.Models;
using Assignment10.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private  BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext cont)
        {
            _logger = logger;
            context = cont;
        }

        public IActionResult Index(long? teamId, string teamname, int PageNum = 0)
        {
            int PageSize = 5;

            return View(new IndexViewModel
            {
                Bowlers = context.Bowlers
                .Where(m => m.TeamId == teamId || teamId == null)
                .OrderBy(p => p.BowlerFirstName)
                .Skip((PageNum - 1) * PageSize)
                .Take(PageSize)
                .ToList(),

                PageNumbering = new PageNumbering
                {
                    NumPerPage = PageSize,
                    CurrentPage = PageNum,
                    //If a team is selected, then just count teams. If not, then just total bowlers.
                    TotalNumItems = teamId == null ? context.Bowlers.Count():
                    context.Bowlers.Where(x=> x.TeamId == teamId).Count()
                },

                teamName = teamname
            });
                
                
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
