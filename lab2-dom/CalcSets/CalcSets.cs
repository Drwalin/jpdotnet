namespace CalcSets;

public class CalcSets : CalcInterface.ICalculator {
	public string GetDescription() {
		return "Kalulator zbiorów liczb całkowitych.\nPrzyjmuje operandy w postacji:\n{1,2,3}\nDostępne operatory:\nSuma: +\nCzęśćwspólna: *\nRóżnica: -";
	}

	public string Process(string a, string op, string b) {
		var _a = TryParse(a);
		var _b = TryParse(b);
		var res = new SortedSet<int>();
		if(_a == null || _b == null) return "Parsing error";

		switch(op) {
			case "+":
				foreach(var it in _a) {
					res.Add(it);
				}
				foreach(var it in _b) {
					res.Add(it);
				}
				break;
			case "-":
				res = _a;
				foreach(var it in _b) {
					if(res.Contains(it)) {
						res.Remove(it);
					}
				}
				break;
			case "*":
				foreach(var it in _a) {
					if(_b.Contains(it)) {
						res.Add(it);
					}
				}
				break;
			default:
				return "Invalid operator error";
		}

		int i = 0;
		var ret = "{";
		foreach(var it in res) {
			if(i > 0) ret += ",";
			ret += it;
			++i;
		}

		ret += "}";

		return ret;
	}

	public bool IsValidOperand(string operand) {
		return TryParse(operand) != null;
	}
	
	public bool IsValidOperator(string op) {
		switch(op) {
			case "+":
			case "-":
			case "*":
				return true;
		}
		return false;
	}


	SortedSet<int> TryParse(string l) {
		var s = new SortedSet<int>();
		l = l.Trim();
		if(l[0] != '{') return null;
		if(l.Last() != '}') return null;
		l = l.Replace("{", "");
		l = l.Replace("}", "");
		var ar = l.Split(",");

		foreach(var it in ar) {
			int v;
			if(!Int32.TryParse(it.Trim().Replace(",",""), out v)) {
				return null;
			}

			s.Add(v);
		}

		return s;
	}
}
