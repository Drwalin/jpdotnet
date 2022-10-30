namespace lab; 

public class OrderMenu {
	public DbContext db;
	public Util util = new();
	private readonly ClientMenu clientMenu;

	public OrderMenu(DbContext db, ClientMenu clientMenu) {
		this.db = db;
		this.clientMenu = clientMenu;
	}
	
	public OrderOrInternetOrder SelectOrder(string text) {
		return Util.ListSelect<OrderOrInternetOrder>((int offset, int count) => db.orders.OrderBy(x => x.Id).Skip(offset).Take(count)
				.ToArray()
		, x => x.ToString(), ()=>db.items.Count(), 10, text);
	}

	public int FinalizeOrders() {
		Util.ListSelect<OrderOrInternetOrder>((int offset, int count) => db.orders.OrderBy(x => x.Id).Skip(offset).Take(count)
				.ToArray()
		, item => item.ToString(), ()=>db.items.Count(), 10, "Choose orders to finalize",
		order => {
			
			return false;
		});
		return 0;
	}

	public int CreateOrder() {
		Console.Clear();

		Item item = new ItemMenu(db).SelectItem("Choose item for new order for " + clientMenu.GetChosenClientString());
		db.Add(new OrderOrInternetOrder() {
			item = item,
			client = clientMenu.chosenClient,
			ip = clientMenu.chosenIClient == null ? "" : clientMenu.chosenIClient.ip,
			discriminatorIsInternetOrder = clientMenu.chosenIClient != null,
			finalized = false
		});

		db.SaveChanges();
		return 0;
	}
}
