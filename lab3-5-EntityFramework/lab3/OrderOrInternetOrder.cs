using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab; 

public class OrderOrInternetOrder {
	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	
	[Required]
	[ForeignKey("Client"), DatabaseGenerated(DatabaseGeneratedOption.None)]	
	public Client client{ get; set; }
	
	[Required]
	[ForeignKey("Item"), DatabaseGenerated(DatabaseGeneratedOption.None)]	
	public Item item { get; set; }
	
	public bool finalized { get; set; }
	
	public string ip { get; set; }
	public bool discriminatorIsInternetOrder { get; set; }

	public string ToString() {
		if(discriminatorIsInternetOrder) {
			return "InternetOrder{Id=" + Id + "client=" + client.Id + ", item=" + item.Id
			       + ", finalized=" + finalized + ", ip=" + ip + "}";
		} else {
			return "Order{Id=" + Id + "client=" + client.Id + ", item=" + item.Id
			       + ", finalized=" + finalized + "}";
		}
	}
}
