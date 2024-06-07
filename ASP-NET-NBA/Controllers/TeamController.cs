﻿using ASP_NET_NBA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBA.DAL;
using NBA.Model;

namespace ASP_NET_NBA.Controllers
{
    public class TeamController : Controller
    {

        private NBAManagerDbContext _dbContext;

        public TeamController(NBAManagerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var teamQuery = _dbContext.Teams
                .Include(p => p.Venue)
                .Include(p => p.Conference)
                .Include(p => p.Coach)
                .AsQueryable();

            var model = teamQuery.ToList();
            this.FillDropdownValues();
            return View(model);
        }

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
                teamQuery = teamQuery.Where(p => p.Conference.Name.ToLower().Contains(filterTeam.Conference.ToLower()));

            var model = teamQuery.ToList();
            return PartialView("_IndexTable", model);
        }

        private void FillDropdownValues()
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
