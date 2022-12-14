using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab;

public class Client {
	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	[Required]
	public string name { get; set; }
	public string address { get; set; }

	public virtual ICollection<OrderOrInternetOrder> orders { get; set; } = new HashSet<OrderOrInternetOrder>();


	public string ToString() {
		return "Client{Id=" + Id + ", name=" + name + ", address=" + address + ", orders.Count=" + orders.Count + "}";
	}

	public float Count() {
		float sum = 0;
		foreach(var it in orders) {
			sum += it.item.price;
		}

		return sum;
	}
}
