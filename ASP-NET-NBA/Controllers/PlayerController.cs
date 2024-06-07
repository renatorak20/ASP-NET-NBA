using ASP_NET_NBA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBA.DAL;
using NBA.Model;

namespace ASP_NET_NBA.Controllers
{
	public class PlayerController : Controller
	{

		private NBAManagerDbContext _dbContext;

		public PlayerController(NBAManagerDbContext dbContext)
		{
			this._dbContext = dbContext;
		}

        [AllowAnonymous]
        public IActionResult Index()
		{
			var playerQuery = _dbContext.Players
				.Include(p => p.Country)
				.Include(p => p.Team)
                .Include(p => p.Position)
				.AsQueryable();

			var model = playerQuery.ToList();
			return View(model);
		}

        [Authorize]
        public IActionResult Details(int? id = null)
		{
			var player = _dbContext.Players
				.Include(p => p.Country)
				.Include(p => p.Team)
				.Include(p => p.Position)
				.Where(p => p.ID == id)
				.FirstOrDefault();

			return View(player);
		}

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            this.FillDropdownValues();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Player model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Players.Add(model);
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
			var model = _dbContext.Players.FirstOrDefault(c => c.ID == id);
			this.FillDropdownValues();
			return View(model);
		}

		[HttpPost]
		[ActionName(nameof(Edit))]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> EditPost(int id)
		{
			var player = _dbContext.Players.Single(c => c.ID == id);

			var ok = await this.TryUpdateModelAsync(player);

			if (ok && this.ModelState.IsValid)
			{
				_dbContext.SaveChanges();
				return RedirectToAction(nameof(Index));
			}

			this.FillDropdownValues();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UploadAttachment(int playerId, IFormFile? file)
		{
			if (file == null)
			{
				return BadRequest("No file uploaded.");
			}

			var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/photos/players");
			if (!Directory.Exists(uploads))
			{
				Directory.CreateDirectory(uploads);
			}

			var filePath = Path.Combine(uploads, file.FileName);

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			var attachment = new PlayerAttachment()
			{
				PlayerID = playerId,
				Path = filePath
			};

			this._dbContext.PlayerAttachments.Add(attachment);
			this._dbContext.SaveChanges();


			return Ok();
		}

		[HttpPost]
		public IActionResult IndexAjax(PlayerFilterModel filterPlayer)
		{
			filterPlayer ??= new PlayerFilterModel();

			var playerQuery = _dbContext.Players.Include(p => p.Country).Include(p => p.Team).AsQueryable();
			if (!string.IsNullOrWhiteSpace(filterPlayer.FullName))
				playerQuery = playerQuery.Where(p => (p.FirstName + " " + p.LastName).ToLower().Contains(filterPlayer.FullName.ToLower()));

			if (!string.IsNullOrWhiteSpace(filterPlayer.Team))
				playerQuery = playerQuery.Where(p => p.Team.Name.ToLower().Contains(filterPlayer.Team.ToLower()));

			if (!string.IsNullOrWhiteSpace(filterPlayer.Country))
				playerQuery = playerQuery.Where(p => p.Country.Name.ToLower().Contains(filterPlayer.Country.ToLower()));

			var model = playerQuery.ToList();
			return PartialView("_IndexTable", model);
		}

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
		{
			Player? playerToDelete = _dbContext.Players.FirstOrDefault(c => c.ID == id);

			if (playerToDelete == null)
			{
				return NotFound();
			}

			_dbContext.Players.Remove(playerToDelete);
			_dbContext.SaveChanges();


			return RedirectToAction(nameof(Index));
		}

		private void FillDropdownValues()
        {
            this.FillTeams();
            this.FillCountries();
            this.FillPositions();
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

        private void FillPositions()
        {
            var teams = new List<SelectListItem>();

            var listItem = new SelectListItem();
            listItem.Text = "- select -";
            listItem.Value = "";
            teams.Add(listItem);

            foreach (var category in _dbContext.Positions)
            {
                listItem = new SelectListItem(category.Name, category.ID.ToString());
                teams.Add(listItem);
            }

            ViewBag.PossiblePositions = teams;
        }

        private void FillCountries()
        {
            var countries = new List<SelectListItem>();

            var listItem = new SelectListItem();
            listItem.Text = "- select -";
            listItem.Value = "";
            countries.Add(listItem);

            foreach (var category in _dbContext.Countries)
            {
                listItem = new SelectListItem(category.Name, category.ID.ToString());
                countries.Add(listItem);
            }

            ViewBag.PossibleCountries = countries;
        }
    }
}
