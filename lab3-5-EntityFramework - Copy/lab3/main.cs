// See https://aka.ms/new-console-template for more information

using System.Net.Mime;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace lab;

partial class main {
	public DbContext db;

	public static void Main(string[] args) {
		main m = new();
		m.MainLoop();
	}

	main() {
		db = new DbContext();
		db.Database.EnsureCreated();

		db.Database.AutoTransactionBehavior = AutoTransactionBehavior.Always;

		Item item = new Item() {description="Opis", price=123.0f, amount=4};
		Client client = new Client() { address = "address", name = "Zerowy" };
		db.Add(item);
		db.Add(client);
		OrderOrInternetOrder order = new OrderOrInternetOrder() { item=item, client=client, discriminatorIsInternetOrder = true, finalized = false, ip="1.2.3.4"};
		db.Add(order);

		item.amount = 666;
		
		db.Add(new Client() { address = "", name = "Drugi" });
		db.Add(new Client() { address = "", name = "Trzeci" });
		db.Add(new Client() { address = "", name = "Czwarty" });
		db.Add(new Client() { address = "", name = "Piaty" });
		db.Add(new Client() { address = "", name = "Szosty" });
		db.Add(new Client() { address = "", name = "Siodmy" });
		db.Add(new Client() { address = "", name = "Oswmy" });
		db.Add(new Client() { address = "", name = "Dziewiaty" });
		db.Add(new Client() { address = "", name = "Jedenasty" });
		db.Add(new Client() { address = "", name = "DwodzestyDrugi" });
		db.Add(new Client() { address = "", name = "DwodzestyTrzeci" });
		db.Add(new Client() { address = "", name = "DwodzestyPierwszy" });
		db.Add(new Client() { address = "", name = "DwodzestySiodmy" });
		db.Add(new Client() { address = "", name = "DwodzestOsmyy" });
		db.Add(new Client() { address = "", name = "DwodzestyCzwart" });


		for(int i = 0; i < 15; ++i) {
			db.Add(new Item() {
				description = "Opis_" + Random.Shared.Next(0, 10),
				price = 123.0f, amount = Random.Shared.Next(0, 10)
			});
		}


		db.SaveChanges();

		MainLoop();
	}

	public void MainLoop() {

		Menu<int> menu = new Menu<int>(true);
		
		menu.AddOption(ConsoleKey.D1, "Client menu", () => {
			return new ClientMenu(db).Menu();
		});
		menu.AddOption(ConsoleKey.D2, "Item menu", () => {
			return new ItemMenu(db).Menu();
		});
		menu.AddOption(ConsoleKey.Q, "Quit", () => {
			db.SaveChanges();
			Environment.Exit(0);
			return 0;
		});

		while(true) {
			menu.Run();
		}
	}
}

