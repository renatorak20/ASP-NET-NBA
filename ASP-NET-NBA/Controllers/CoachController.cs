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
	public class CoachController : Controller
	{

		private NBAManagerDbContext _dbContext;

		public CoachController(NBAManagerDbContext dbContext)
		{
			this._dbContext = dbContext;
		}

		public IActionResult Index()
		{
			var coachQuery = _dbContext.Coaches
				.Include(p => p.Country)
				.Include(p => p.Team)
				.AsQueryable();

			var model = coachQuery.ToList();
			return View(model);
		}

		public IActionResult Details(int? id = null)
		{
			var coach = _dbContext.Coaches
                .Include(p => p.Country)
				.Include(p => p.Team)
				.Where(p => p.ID == id)
				.FirstOrDefault();

			return View(coach);
		}

        public IActionResult Create()
        {
            this.FillDropdownValues();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Coach model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Coaches.Add(model);
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
		public IActionResult Edit(int id)
		{
			var model = _dbContext.Coaches.FirstOrDefault(c => c.ID == id);
			this.FillDropdownValues();
			return View(model);
		}

		[HttpPost]
		[ActionName(nameof(Edit))]
		public async Task<IActionResult> EditPost(int id)
		{
			var coach = _dbContext.Coaches.Single(c => c.ID == id);

			var ok = await this.TryUpdateModelAsync(coach);

			if (ok && this.ModelState.IsValid)
			{
				_dbContext.SaveChanges();
				return RedirectToAction(nameof(Index));
			}

			this.FillDropdownValues();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UploadAttachment(int coachId, IFormFile? file)
		{
			if (file == null)
			{
				return BadRequest("No file uploaded.");
			}

			var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/photos/coaches");
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
				PlayerID = coachId,
				Path = filePath
			};

			this._dbContext.PlayerAttachments.Add(attachment);
			this._dbContext.SaveChanges();


			return Ok();
		}

		[HttpPost]
		public IActionResult IndexAjax(PlayerFilterModel filterCoach)
		{
			filterCoach ??= new PlayerFilterModel();

			var coachQuery = _dbContext.Coaches.Include(p => p.Country).Include(p => p.Team).AsQueryable();
			if (!string.IsNullOrWhiteSpace(filterCoach.FullName))
				coachQuery = coachQuery.Where(p => (p.FirstName + " " + p.LastName).ToLower().Contains(filterCoach.FullName.ToLower()));

			if (!string.IsNullOrWhiteSpace(filterCoach.Team))
				coachQuery = coachQuery.Where(p => p.Team.Name.ToLower().Contains(filterCoach.Team.ToLower()));

			if (!string.IsNullOrWhiteSpace(filterCoach.Country))
				coachQuery = coachQuery.Where(p => p.Country.Name.ToLower().Contains(filterCoach.Country.ToLower()));

			var model = coachQuery.ToList();
			return PartialView("_IndexTable", model);
		}

		public IActionResult Delete(int id)
		{
            Coach? coachToDelete = _dbContext.Coaches.FirstOrDefault(c => c.ID == id);

			if (coachToDelete == null)
			{
				return NotFound();
			}

			_dbContext.Coaches.Remove(coachToDelete);
			_dbContext.SaveChanges();


			return RedirectToAction(nameof(Index));
		}

		private void FillDropdownValues()
        {
            this.FillTeams();
            this.FillCountries();
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
