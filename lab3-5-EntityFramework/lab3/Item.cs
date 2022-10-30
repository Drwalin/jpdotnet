using System.ComponentModel.DataAnnotations;

namespace lab;

public class Item {
	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public string? description { get; set; }
	public float price { get; set; }
	public int amount { get; set; }
	
	public virtual ICollection<OrderOrInternetOrder> orders { get; set; } = new HashSet<OrderOrInternetOrder>();

	public string ToString() {
		return "Item{Id=" + Id + ", description=" + description + ", price="
		       + price + ", amount=" + amount + ", orders.Count=" + orders.Count + "}";
	}
}