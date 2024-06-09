using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBA.DAL;
using NBA.Model;

namespace ASP_NET_NBA.Controllers
{
	[Route("api/team")]
	[ApiController]
	public class TeamApiController : Controller
	{
		private NBAManagerDbContext _dbContext;

		public TeamApiController(NBAManagerDbContext dbContext)
		{
			this._dbContext = dbContext;
		}

		[HttpGet]
		public IActionResult Get()
		{
			List<TeamDTO> players = _dbContext.Teams
				.Include(t => t.Venue)
				.Include(t => t.Conference)
				.Select(t => toTeamDTO(t))
				.ToList();

			return Ok(players);
		}

		[HttpGet]
		[Route("{id}")]
		public IActionResult Get(int id)
		{
            TeamDTO? player = _dbContext.Teams
                .Include(t => t.Venue)
                .Include(t => t.Conference)
                .Where(p => p.ID == id)
				.Select(t => toTeamDTO(t))
				.FirstOrDefault();

			return player == null ? NotFound() : Ok(player);
		}

		[HttpGet]
		[Route("search/{q}")]
		public IActionResult Get(string q)
		{
			List<TeamDTO> clients = _dbContext.Teams
                .Include(t => t.Venue)
                .Include(t => t.Conference)
                .Where(t => t.Name.Contains(q))
				.Select(t => toTeamDTO(t))
				.ToList();

			return Ok(clients);
		}	

		public class TeamDTO
		{
			public int ID { get; set; }
			public string Name { get; set; }
		}

		public class CoachDTO
		{
			public int? ID { get; set; }
			public string? Name { get; set; }
		}

		public static TeamDTO toTeamDTO(Team t)
		{
			return new TeamDTO()
			{
				ID = t.ID,
                Name = t.Name
			};
		}
	}
}
