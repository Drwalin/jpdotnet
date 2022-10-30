namespace lab; 

public class Menu<Ret> {
	class Pair {
		public string name;
		public Func<Ret> function;
		public ConsoleKey key;
	}

	private List<Pair> options = new List<Pair>();
	private string text;
	private bool clear;

	public Menu(bool clear) {
		this.clear = clear;
	}

	public void AddOption(ConsoleKey key, string name, Func<Ret> function) {
		options.Add(new Pair(){name=name, function=function, key=key});
	}

	public void SetDescription(string text) {
		this.text = text;
	}

	public Ret Run() {
		bool printed = false;
		while(true) {
			if(clear) {
				Console.Clear();
				printed = false;
			}

			if(printed == false) {
				foreach(var it in options) {
					Console.WriteLine("" + it.key + ", " + it.name);
				}
			}
			
			var k = Console.ReadKey();
			ConsoleKey key = k.Key;
			foreach(var it in options) {
				if(key == it.key) {
					return it.function();
				}
			}
		}
	}
}
