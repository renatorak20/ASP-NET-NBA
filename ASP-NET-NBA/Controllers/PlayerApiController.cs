using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBA.DAL;
using NBA.Model;

namespace ASP_NET_NBA.Controllers
{
	[Route("api/player")]
	[ApiController]
	public class PlayerApiController : Controller
	{
		private NBAManagerDbContext _dbContext;

		public PlayerApiController(NBAManagerDbContext dbContext)
		{
			this._dbContext = dbContext;
		}

		[HttpGet]
		public IActionResult Get()
		{
			List<PlayerDTO> players = _dbContext.Players
				.Include(p => p.Team)
                .Include(p => p.Position)
                .Select(p => toPlayerDTO(p))
				.ToList();

			return Ok(players);
		}

		[HttpGet]
		[Route("{id}")]
		public IActionResult Get(int id)
		{
			PlayerDTO? player = _dbContext.Players
				.Include(p => p.Team)
				.Include(p => p.Position)
				.Where(p => p.ID == id)
				.Select(p => toPlayerDTO(p))
				.FirstOrDefault();

			return player == null ? NotFound() : Ok(player);
		}

		[HttpGet]
		[Route("search/{q}")]
		public IActionResult Get(string q)
		{
			List<PlayerDTO> clients = _dbContext.Players
				.Include(p => p.Team)
				.Include(p => p.Position)
				.Where(p => p.FirstName.Contains(q))
				.Select(p => toPlayerDTO(p))
				.ToList();

			return Ok(clients);
		}

		[HttpPost]
		public IActionResult Post([FromBody] Player player)
		{
			_dbContext.Add(player);
			_dbContext.SaveChanges();

			return Get(player.ID);
		}

		[HttpPut]
		[Route("{id}")]
		public IActionResult Put(int id, [FromBody] Player player)
		{
			Player? playerForUpdate = this._dbContext.Players.FirstOrDefault(p => p.ID == id);
			if (playerForUpdate != null)
			{
				playerForUpdate.FirstName = player.FirstName;
				playerForUpdate.LastName = player.LastName;
				playerForUpdate.Height = player.Height;
				playerForUpdate.Weight = player.Weight;
				playerForUpdate.DateOfBirth = player.DateOfBirth;
				playerForUpdate.PositionID = player.PositionID;
				playerForUpdate.CountryID = player.CountryID;

				if (player.TeamID != null)
					playerForUpdate.TeamID = player.TeamID;

				if (_dbContext.Players.Where(p => p.ID == id).FirstOrDefault() == null)
				{
					return NotFound("Player with ID " + player.ID + " is not found!");
				}

				if (_dbContext.Positions.Where(p => p.ID == player.PositionID).FirstOrDefault() == null)
				{
					return NotFound("Position with ID " + player.PositionID + " is not found!");
				}

				if (_dbContext.Countries.Where(c => c.ID == player.CountryID).FirstOrDefault() == null)
				{
					return NotFound("Country with ID " + player.CountryID + " is not found!");
				}

				if (_dbContext.Teams.Where(t => t.ID == player.TeamID).FirstOrDefault() == null)
				{
					return NotFound("Team with ID " + player.TeamID + " is not found!");
				}

				this._dbContext.SaveChanges();
				return Ok();
			}
			else
			{
				return NotFound();
			}
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			Player? playerToDelete = _dbContext.Players.FirstOrDefault(p => p.ID == id);

			if (playerToDelete == null)
			{
				return NotFound();
			}

			_dbContext.Players.Remove(playerToDelete);
			_dbContext.SaveChanges();

			return Ok();
		}

		public class PlayerDTO
		{
			public int ID { get; set; }
			public string FullName { get; set; }
			public PositionDTO Position { get; set; }
			public TeamDTO? Team { get; set; }
		}

		public class TeamDTO
		{
			public int ID { get; set; }
			public string Name { get; set; }
		}

		public class PositionDTO
		{
			public int ID { get; set; }
			public string Name { get; set; }
		}

		public static PlayerDTO toPlayerDTO(Player p)
		{
			return new PlayerDTO()
			{
				ID = p.ID,
				FullName = p.FullName,
				Position = new PositionDTO() { ID = p.Position.ID, Name = p.Position.Name },
				Team = new TeamDTO() { ID = p.Team.ID, Name = p.Team.Name }
			};
		}
	}
}
