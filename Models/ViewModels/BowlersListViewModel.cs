using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueDirectory.Models.ViewModels
{
    public class BowlersListViewModel
    {
        public IEnumerable<Bowlers> BowlerList { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; } //current team selected
    }
}
