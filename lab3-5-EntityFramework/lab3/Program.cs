// See https://aka.ms/new-console-template for more information

using System.Net.Mime;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace lab;

partial class Program {
	public static DbContext db;
	public static InternetClient chosenIClient;
	public static Client chosenClient;

	public static void Main(string[] args) {
		db = new DbContext();
		db.Database.EnsureCreated();

		db.Database.AutoTransactionBehavior = AutoTransactionBehavior.Always;

		Item item = new Item();
		Client client = new Client() { address = "address", name = "Zerowy" };
		OrderOrInternetOrder order = new OrderOrInternetOrder() { item=item, client=client, discriminatorIsInternetOrder = true, finalized = false, ip="1.2.3.4"};
		db.Add(item);
		db.Add(client);
		db.Add(order);
		
		/*
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
		*/
		db.SaveChanges();

		MainLoop();

		db.SaveChanges();
	}

	public static void MainLoop() {
		ChooseClient();
		while(true) {
			Console.Clear();
			Console.WriteLine("Chosen client: "
			                  + (chosenIClient != null
				                  ? chosenIClient
				                  : chosenClient));
			Console.WriteLine("1. Choose Client");
			Console.WriteLine("2. Create Client");
			Console.WriteLine("3. Create Item");
			Console.WriteLine("4. Browse Items");
			Console.WriteLine("5. Browse Orders");
			Console.WriteLine("6. Create Order");
			switch(Console.ReadKey().KeyChar) {
				case '1':
					ChooseClient();
					break;
				case '2':
					CreateClient();
					break;
				case '3':
					BrowseItems();
					break;
				case '4':
					CreateItem();
					break;
				case '5':
					BrowseOrders();
					break;
				case '6':
					CreateOrder();
					break;
			}
		}

	}

	public static bool ChooseClient() {
		string filter = "";
		while(true) {
			PrintFilter(filter);
			ConsoleKeyInfo key = Console.ReadKey();
			if(key.Key == ConsoleKey.Escape) {
				Environment.Exit(0);
			} else if(key.Key == ConsoleKey.Enter) {
				var clients = SelectTop(filter);
				chosenClient = null;
				chosenIClient = null;
				foreach(var c in clients) {
					var ic = db.internetClients.Where(x => x.client.Equals(c))
						.Take(1)
						.ToArray();
					if(ic?.Length > 0) {
						chosenIClient = ic[0];
					}

					chosenClient = c;
					break;
				}

				if(chosenClient != null) {
					return true;
				}
			} else if(key.Key == ConsoleKey.Backspace) {
				if(filter.Length > 0) {
					filter = filter.Substring(0, filter.Length - 1);
				}
			} else {
				filter += key.KeyChar;
			}
		}
	}

	static void PrintFilter(string filter) {
		Console.Clear();
		var clients = SelectTop(filter);
		int i = 0;
		foreach(var c in clients) {
			var ic = db.internetClients.Where(x => x.client.Equals(c))
				.Take(1)
				.ToArray();
			if(ic?.Length > 0) {
				Console.WriteLine("" + i + ": " + ic[0].ToString());
			} else {
				Console.WriteLine("" + i + ": " + c.ToString());
			}

			++i;
		}

		Console.WriteLine("Found: " + i);
		Console.WriteLine("Filter: " + filter);
	}

	public static Client[] SelectTop(string filter) {
		return db.clients
			.Where(x => x.name.ToLower().Contains(filter.ToLower()))
			.OrderBy(x => x.name).Take(10).ToArray();
	}

	
	private static void CreateClient() {
		Console.Clear();
		string name;
		string address;
		string ip;
		Console.Clear();
		Console.WriteLine("Creating new client");

		Console.WriteLine("Give name:");
		name = Console.ReadLine().Trim();
		Console.WriteLine("Give address:");
		address = Console.ReadLine().Trim();
		Console.WriteLine("If client should be an InternetClient then type ip address, otherwise type nothing:");
		ip = Console.ReadLine().Trim();

		Client client = new Client() { name = name, address = address };
		db.Add(client);
		if(ip.Length > 0) {
			db.Add(new InternetClient() { client = client, ip = ip });
		}
		db.SaveChanges();
	}

	
	
	
	
	
	
	
	
	
	
	
	
	
	
	

	private static void CreateItem() {
		throw new NotImplementedException();
	}
	
	
	
	
	
	
	private static void BrowseOrders() {
		Console.Clear();
	}

	private static void CreateOrder() {
		Console.Clear();
		Console.WriteLine("Creating new order for: "
		                  + (chosenIClient != null
			                  ? chosenIClient
			                  : chosenClient));
		Item item;
		while(true) {
			int itemId = ReadInt("Item Id");
			var it = db.items.Where(x => x.Id == itemId).ToArray();
			if(it.Length == 1) {
				item = it[0];
				break;
			}

			Console.WriteLine("Item with id: " + itemId + " does not exist");
		}

		if(chosenIClient != null) {
			db.Add(new OrderOrInternetOrder() {
				item = item,
				client = chosenClient,
				ip = chosenIClient == null ? "" : chosenIClient.ip,
				discriminatorIsInternetOrder = chosenIClient != null,
				finalized = false
			});
		}

		db.SaveChanges();
	}



	private static void SearchClientByItem() {
		Console.Clear();
	}


	private static void BrowseItems() {
		//if(...) browseClientByItem();
	}

	public static int ReadInt(string name) {
		Console.WriteLine(name + ": ");
		while(true) {
			string line = Console.ReadLine();
			int value;
			if(Int32.TryParse(line, out value)) {
				return value;
			}

			Console.WriteLine("Invalid " + name + ", Pleas write again: ");
		}
	}

	public static bool ReadYesNo(string name) {
		return ReadInt(name + " (0 - no, !0 - yes)") != 0;
	}



	private static object ListSelect(Func<int, int, Object[]> select,
		Func<Object, string> toString, Func<int> count, int pageSize,
		string header) {
		int page = 0;
		int all = count();
		int maxPage = ((all + pageSize - 1) / pageSize);
		while(true) {
			Console.Clear();
			Console.WriteLine(header);
			Object[] objects = select(page * pageSize, pageSize);
			for(int i = 0; i < objects.Length; ++i) {
				Console.WriteLine("" + i + ": " + toString(objects[i]));
			}
			Console.WriteLine("Page: " + page + " / " + maxPage);
			Console.WriteLine("Press 0-9 to select element");
			Console.WriteLine("Press enter to select none");
			Console.WriteLine("Press n/p to go to next/previous page");
			
			ConsoleKeyInfo key = Console.ReadKey();
			if(key.KeyChar >= '0' && key.KeyChar <= '9') {
				int id = key.KeyChar - '0';
				if(id >= objects.Length) {
					continue;
				}
			} else {
				switch(key.Key) {
					case ConsoleKey.N:
						page = Math.Clamp(page + 1, 0, maxPage);
						break;
					case ConsoleKey.P:
						page = Math.Clamp(page - 1, 0, maxPage);
						break;
					case ConsoleKey.Enter:
						return null;
				}
			}
		}
	}
}

