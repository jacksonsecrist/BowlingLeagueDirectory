using BowlingLeagueDirectory.Models;
using BowlingLeagueDirectory.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueDirectory.Controllers
{
    public class HomeController : Controller
    {
        //properties
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext _context;
        public int PageSize = 5;

        //constructor
        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext con)
        {
            _logger = logger;
            _context = con;
        }

        //methods
        public IActionResult Index(string category, int pageNum = 1)
        {
            BowlersListViewModel viewModel = new BowlersListViewModel
            {
                //get bowlers using team filter if there is one
                BowlerList = _context.Bowlers.Where(b => category == null || b.Team.TeamName == category).OrderBy(b => b.BowlerId).Skip((pageNum - 1) * PageSize).Take(PageSize), 
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    TotalNumItems = category == null ? _context.Bowlers.Count() : _context.Bowlers.Where(b => b.Team.TeamName == category).Count()
                },
                CurrentCategory = category
            };
            return View(viewModel);
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
