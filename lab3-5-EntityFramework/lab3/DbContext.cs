using Microsoft.EntityFrameworkCore;

namespace lab;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext {
	public DbSet<Item> items { get; set; }
	public DbSet<OrderOrInternetOrder> orders { get; set; }
	public DbSet<Client> clients { get; set; }
	public DbSet<InternetClient> internetClients { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder options) {
		options.UseSqlite("DataSource=..\\..\\..\\..\\DataBase.sqlite");
	}
}
