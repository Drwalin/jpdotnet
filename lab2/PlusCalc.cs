namespace lab2;

    public class PlusCalc : ICalculator
    {
        public string Eval(string a, string b)
        {
            return (Int64.Parse(a) + Int64.Parse(b)).ToString();
        }
    }