using BowlingLeagueDirectory.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueDirectory.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private BowlingLeagueContext _context;

        public NavigationMenuViewComponent(BowlingLeagueContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_context.Teams.Select(t => t.TeamName).Distinct().OrderBy(t => t)); //Pulls from DBSet Teams to include the teams that do not have any bowlers
        }
    }
}
