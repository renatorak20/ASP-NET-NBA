using ASP_NET_NBA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBA.DAL;
using NBA.Model;

namespace ASP_NET_NBA.Controllers
{
    public class GameController : Controller
    {

        private NBAManagerDbContext _dbContext;

        public GameController(NBAManagerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var gameQuery = _dbContext.Games
                .Include(p => p.Venue)
                .Include(p => p.TeamAway)
                .Include(p => p.TeamHome)
                .AsQueryable();

            var model = gameQuery.ToList();
            this.FillDropdownValues();
            return View(model);
        }

        [Authorize]
        public IActionResult Details(int? id = null)
		{
			var team = _dbContext.Teams
				.Include(p => p.Venue)
				.Include(p => p.Conference)
				.Include(p => p.Coach)
				.Where(p => p.ID == id)
				.FirstOrDefault();

			if (team == null)
			{
				return NotFound();
			}

			var players = _dbContext.Players
				.Include(p => p.Position)
				.Include(p => p.Country)
				.Where(p => p.TeamID == id)
				.ToList();

			var viewModel = new TeamDetailsViewModel
			{
				Team = team,
				Players = players
			};

			return View(viewModel);
		}

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            this.FillDropdownValues();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Game model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Games.Add(model);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                this.FillDropdownValues();
                return View();
            }
        }


        [HttpPost]
        public IActionResult IndexAjax(TeamFilterModel filterTeam)
        {
            filterTeam ??= new TeamFilterModel();

            var teamQuery = _dbContext.Teams.Include(p => p.Venue).Include(p => p.Coach).Include(p => p.Conference).AsQueryable();
            if (!string.IsNullOrWhiteSpace(filterTeam.Venue))
                teamQuery = teamQuery.Where(p => (p.Venue.Name).Contains(filterTeam.Venue, StringComparison.CurrentCultureIgnoreCase));

            if (!string.IsNullOrWhiteSpace(filterTeam.Team))
                teamQuery = teamQuery.Where(p => p.Name.ToLower().Contains(filterTeam.Team.ToLower()));

            if (!string.IsNullOrWhiteSpace(filterTeam.Conference))
                teamQuery = teamQuery.Where(p => p.Conference.ID.ToString().ToLower().Contains(filterTeam.Conference.ToLower()));

            var model = teamQuery.ToList();
            return PartialView("_IndexTable", model);
        }

        private void FillDropdownValues()
        {
            FillTeams();
            FillVenues();
        }

        private void FillTeams()
        {
            var teams = new List<SelectListItem>();

            var listItem = new SelectListItem();
            listItem.Text = "- select -";
            listItem.Value = "";
            teams.Add(listItem);

            foreach (var category in _dbContext.Teams)
            {
                listItem = new SelectListItem(category.Name, category.ID.ToString());
                teams.Add(listItem);
            }

            ViewBag.PossibleTeams = teams;
        }

        private void FillVenues()
        {
            var venues = new List<SelectListItem>();

            var listItem = new SelectListItem();
            listItem.Text = "- select -";
            listItem.Value = "";
            venues.Add(listItem);

            foreach (var category in _dbContext.Venues)
            {
                listItem = new SelectListItem(category.Name, category.ID.ToString());
                venues.Add(listItem);
            }

            ViewBag.PossibleVenues = venues;
        }
    }
}
