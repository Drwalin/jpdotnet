using System.ComponentModel.DataAnnotations;

namespace lab;

public class InternetClient {
	
	public int Id { get; set; }
	
	[Key]
	public Client client { get; set; }
	public string ip { get; set; }

	public string ToString() {
		return "Client{Id=" + Id + "name=" + client.name + ", address=" + client.address + ", ip=" + ip + "}";
	}
}
