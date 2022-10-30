namespace lab; 

public class ItemMenu {
	public DbContext db;
	public Util util = new();

	public ItemMenu(DbContext db) {
		this.db = db;
	}
	

	private void CreateItem() {
		Console.Clear();
		Console.WriteLine("Creating new item");

		Console.WriteLine("Give description:");
		string description = Console.ReadLine().Trim();
		float price = Util.ReadFloat("Give privce");
		int amount = Util.ReadInt("Give amount");

		db.Add(new Item()
			{ description = description, price = price, amount = amount });
		db.SaveChanges();
	}


	public int Menu() {
		Util.ListSelect<Item>((int offset, int count) => db.items.OrderBy(x => x.description).Skip(offset).Take(count)
				.ToArray(), (Item Item) => Item.ToString(), ()=>db.items.Count(), 5, "Select an item",
			(Item item) => {
				SingleItemMenu(item);
				return false;
			});
		return 0;
	}

	private void SingleItemMenu(Item item) {
		bool run = true;
		while(run) {
			Menu<int> menu = new Menu<int>(true);

			menu.AddOption(ConsoleKey.D1, "Edit item price", ()=> {
				return EditItemPrice(item);
			});
			menu.AddOption(ConsoleKey.D2, "Add item amount", () => {
				return EditItemAmount(item);
			});
			menu.AddOption(ConsoleKey.D3, "Browse clients by item",
				BrowseClientsByItem);

			menu.AddOption(ConsoleKey.Q, "Return", () => {
				run = false;
				return 0;
			});

			menu.Run();
		}
	}
	private int EditItemPrice(Item item) {
		Console.WriteLine("Item: " + item);
		item.price = Util.ReadFloat("New item price");
		return 0;
	}

	private int EditItemAmount(Item item) {
		while(true) {
			int amount = Util.ReadInt("How much items to add to: " + item);
			if(amount < 0) {
				Console.WriteLine("Amount must not be less than 0");
			} else {
				item.amount += amount;
				db.SaveChanges();
				return 0;
			}
		}
	}

	private int BrowseClientsByItem() {
		
	}

	public Item SelectItem(string text) {
		return Util.ListSelect<Item>((int offset, int count) => db.items.OrderBy(x => x.description).Skip(offset).Take(count)
				.ToArray()
		, (Item Item) => Item.ToString(), ()=>db.items.Count(), 5, text);
	}
}
