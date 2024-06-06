using Microsoft.EntityFrameworkCore;
using NBA.Model;

namespace NBA.DAL
{
	public class NBAManagerDbContext: DbContext
	{
		public NBAManagerDbContext(DbContextOptions<NBAManagerDbContext> options) : base(options) { }

		public DbSet<Player> Players { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<Position> Positions { get; set; }
		public DbSet<Country> Countries { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Position>().HasData(
				new Position { ID = 1, Name = "Point Guard (PG)" },
				new Position { ID = 2, Name = "Shooting Guard (SG)" },
				new Position { ID = 3, Name = "Small Forward (SF)" },
				new Position { ID = 4, Name = "Power Forward (PF)" },
				new Position { ID = 5, Name = "Center (C)" }
			);
		}

	}
}
