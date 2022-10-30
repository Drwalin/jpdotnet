namespace lab; 

public class Util {
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
	
	public static float ReadFloat(string name) {
		Console.WriteLine(name + ": ");
		while(true) {
			string line = Console.ReadLine();
			double value;
			if(Double.TryParse(line, out value)) {
				return (float)value;
			}

			Console.WriteLine("Invalid " + name + ", Pleas write again: ");
		}
	}

	public static bool ReadYesNo(string name) {
		return ReadInt(name + " (0 - no, !0 - yes)") != 0;
	}

	public static T ListSelect<T>(Func<int, int, T[]> select,
		Func<T, string> toString, Func<int> count, int pageSize,
		string header, Func<T, bool> finalizeSelect = null) where T : class {
		int page = 0;
		int all = count();
		int maxPage = ((all + pageSize - 1) / pageSize);
		while(true) {
			Console.Clear();
			Console.WriteLine(header);
			T[] objects = select(page * pageSize, pageSize);
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
				} else {
					if(finalizeSelect != null) {
						if(finalizeSelect(objects[id])) {
							return objects[id];
						}
					} else {
						return objects[id];
					}
				}
			} else {
				switch(key.Key) {
					case ConsoleKey.N:
						page = Math.Clamp(page + 1, 0, maxPage);
						break;
					case ConsoleKey.P:
						page = Math.Clamp(page - 1, 0, maxPage);
						break;
					case ConsoleKey.Q:
						return null;
				}
			}
		}
	}
}
