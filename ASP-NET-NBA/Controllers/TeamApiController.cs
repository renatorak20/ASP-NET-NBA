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
				.Include(p => p.Venue)
				.Include(p => p.Conference)
				.Include(p => p.Coach)
				.Select(p => toTeamDTO(p))
				.ToList();

			return Ok(players);
		}

		[HttpGet]
		[Route("{id}")]
		public IActionResult Get(int id)
		{
            TeamDTO? player = _dbContext.Teams
                .Include(p => p.Venue)
                .Include(p => p.Conference)
                .Include(p => p.Coach)
                .Where(p => p.ID == id)
				.Select(p => toTeamDTO(p))
				.FirstOrDefault();

			return player == null ? NotFound() : Ok(player);
		}

		[HttpGet]
		[Route("search/{q}")]
		public IActionResult Get(string q)
		{
			List<TeamDTO> clients = _dbContext.Teams
                .Include(p => p.Venue)
                .Include(p => p.Conference)
                .Include(p => p.Coach)
                .Where(p => p.Name.Contains(q))
				.Select(p => toTeamDTO(p))
				.ToList();

			return Ok(clients);
		}	

		public class TeamDTO
		{
			public int ID { get; set; }
			public string Name { get; set; }
			public CoachDTO? Coach { get; set; }
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
                Name = t.Name,
                Coach = new CoachDTO() { ID = t?.Coach?.ID, Name = t?.Coach?.FullName }
			};
		}
	}
}
