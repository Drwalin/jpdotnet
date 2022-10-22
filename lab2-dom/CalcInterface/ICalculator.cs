namespace CalcInterface;

public interface ICalculator {
	string GetDescription();
	string Process(string a, string op, string b);
	bool IsValidOperand(string operand);
	bool IsValidOperator(string op);
}
