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
                .Include(g => g.Venue)
                .Include(g => g.TeamAway)
                .Include(g => g.TeamHome)
                .AsQueryable();

            var model = gameQuery.ToList();
            this.FillDropdownValues();
            return View(model);
        }

        [Authorize]
        public IActionResult Details(int? id = null)
		{
			var team = _dbContext.Teams
				.Include(t => t.Venue)
				.Include(t => t.Conference)
				.Where(t => t.ID == id)
				.FirstOrDefault();

            var coachesCount = _dbContext.Coaches.
                Include(c => c.TeamID)
                .Where(c => c.TeamID == id).Count();

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
				Players = players,
                CoachesCount = coachesCount
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

		[ActionName(nameof(Edit))]
		[Authorize(Roles = "Admin, Manager")]
		public IActionResult Edit(int id)
		{
			var model = _dbContext.Games.FirstOrDefault(c => c.ID == id);
			this.FillDropdownValues();
			return View(model);
		}

		[HttpPost]
		[ActionName(nameof(Edit))]
		[Authorize(Roles = "Admin, Manager")]
		public async Task<IActionResult> EditPost(int id)
		{
			var game = _dbContext.Games.Single(c => c.ID == id);

			var ok = await this.TryUpdateModelAsync(game);

			if (ok && this.ModelState.IsValid)
			{
				_dbContext.SaveChanges();
				return RedirectToAction(nameof(Index));
			}

			this.FillDropdownValues();
			return View();
		}

		[Authorize(Roles = "Admin")]
		public IActionResult Delete(int id)
		{
			Game? gameToDelete = _dbContext.Games.FirstOrDefault(g => g.ID == id);

			if (gameToDelete == null)
			{
				return NotFound();
			}

			_dbContext.Games.Remove(gameToDelete);
			_dbContext.SaveChanges();


			return RedirectToAction(nameof(Index));
		}


		[HttpPost]
        public IActionResult IndexAjax(GameFilterModel filterGame)
        {
            filterGame ??= new GameFilterModel();

            var gameQuery = _dbContext.Games.Include(g => g.Venue).Include(g => g.TeamHome).Include(g => g.TeamAway).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterGame.Team))
                gameQuery = gameQuery.Where(g => g.TeamHome.Name.ToLower().Contains(filterGame.Team.ToLower()) || g.TeamAway.Name.ToLower().Contains(filterGame.Team.ToLower()));

            var model = gameQuery.ToList();
            return PartialView("_IndexTable", model);
        }

        private void FillDropdownValues()
        {
            FillTeams();
            FillVenues();
            FillConferences();

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

		private void FillConferences()
		{
			var conferences = new List<SelectListItem>();

			var listItem = new SelectListItem();
			listItem.Text = "- select -";
			listItem.Value = "";
			conferences.Add(listItem);

			foreach (var category in _dbContext.Conferences)
			{
				listItem = new SelectListItem(category.Name, category.ID.ToString());
				conferences.Add(listItem);
			}

			ViewBag.PossibleConferences = conferences;
		}
	}
}
