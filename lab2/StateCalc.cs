namespace lab2;


    public class StateCalc : ICalculator
    {
        private int val;

        public StateCalc(int v)
        {
            val = v;
        }

        public string Eval(string a, string b)
        {
            var x = a + b + val;
            val++;
            return x;
        }
    }