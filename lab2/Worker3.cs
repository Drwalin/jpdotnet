namespace lab2;
	public class Worker3
	{
		public ICalculator Calculator { get; set; }

		public void Work(string a, string b)
		{
			Console.Out.WriteLine(Calculator.Eval(a, b));
		}
	}

