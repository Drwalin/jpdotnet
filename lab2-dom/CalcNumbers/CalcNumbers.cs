namespace CalcNumbers;

public class CalcNumbers : CalcInterface.ICalculator {
	public string GetDescription() {
		return "Kalulator liczb całkowitych 32 bit.";
	}

	public string Process(string a, string op, string b) {
		int _a = Int32.Parse(a);
		int _b = Int32.Parse(b);
		int res = 0;

		switch(op) {
			case "+":
				res = _a + _b;
				break;
			case "-":
				res = _a - _b;
				break;
			case "*":
				res = _a * _b;
				break;
			case "/":
				res = _a / _b;
				break;
			default:
				return "Invalid operator error";
		}

		return "" + res;
	}

	public bool IsValidOperand(string operand) {
		int _a;
		return Int32.TryParse(operand, out _a);
	}

	public bool IsValidOperator(string op) {
		switch(op) {
			case "+":
			case "-":
			case "*":
			case "/":
				return true;
		}

		return false;
	}
}
