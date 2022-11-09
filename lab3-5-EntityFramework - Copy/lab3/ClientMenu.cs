namespace lab;

public class ClientMenu {
	public DbContext db;
	
	public InternetClient chosenIClient;
	public Client chosenClient;

	public ClientMenu(DbContext db) {
		this.db = db;
	}

	public int BrowseClients() {
		Util.ListSelect<Client>((int offset, int count) => db.clients.OrderBy(x => x.name).Skip(offset).Take(count)
				.ToArray()
		, (Client client) => client.ToString(), ()=>db.items.Count(), 5, "Browse clients",
		(Client client) => {
			chosenClient = client;
			chosenIClient = null;
			var ic = db.internetClients.Where(x => x.client.Equals(client))
				.Take(1)
				.ToArray();
			if(ic?.Length > 0) {
				chosenIClient = ic[0];
			}
			return true;
		});
		return 0;
	}

	public int ChooseClient() {
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
					return 1;
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

	void PrintFilter(string filter) {
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

	public Client[] SelectTop(string filter) {
		return db.clients
			.Where(x => x.name.ToLower().Contains(filter.ToLower()))
			.OrderBy(x => x.name).Take(10).ToArray();
	}

	private int CreateClient() {
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
		Console.WriteLine(
			"If client should be an InternetClient then type ip address, otherwise type nothing:");
		ip = Console.ReadLine().Trim();

		Client client = new Client() { name = name, address = address };
		db.Add(client);
		if(ip.Length > 0) {
			db.Add(new InternetClient() { client = client, ip = ip });
		}

		db.SaveChanges();
		
		return 0;
	}

	public int Menu() {
		bool run = true;
		chosenClient = null;
		chosenIClient = null;
		while(run) {
			Menu<int> menu = new Menu<int>(true);

			menu.AddOption(ConsoleKey.D1, "Choose client", ChooseClient);
			menu.AddOption(ConsoleKey.D2, "Browse clients", BrowseClients);
			menu.AddOption(ConsoleKey.D3, "Add client", CreateClient);
			if(chosenClient != null) {
				menu.AddOption(ConsoleKey.D4, "Finalize orders", () => {
					return new OrderMenu(db, this).FinalizeOrders();
				});
				menu.AddOption(ConsoleKey.D5, "Create order", () => {
					return new OrderMenu(db, this).CreateOrder();
				});
			}
			menu.AddOption(ConsoleKey.Q, "Return", () => {
				run = false;
				return 0;
			});
			
			menu.SetDescription("Choosen client: " + GetChosenClientString());

			menu.Run();
		};

		return 0;
	}

	public string GetChosenClientString() {
		if(chosenIClient != null) {
			return chosenIClient.ToString();
		} else if(chosenClient != null) {
			return chosenClient.ToString();
		} else {
			return "[NULL]";
		}
	}
}
