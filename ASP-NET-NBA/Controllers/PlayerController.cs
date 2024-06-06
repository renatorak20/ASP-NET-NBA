using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NBA.DAL;

namespace ASP_NET_NBA.Controllers
{
	public class PlayerController : Controller
	{

		private NBAManagerDbContext _dbContext;

		public PlayerController(NBAManagerDbContext dbContext)
		{
			this._dbContext = dbContext;
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
