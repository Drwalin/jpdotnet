namespace lab2;


    public class Worker2
    {
        private ICalculator calc = null;

        public void SetCalculator(ICalculator c)
        {
            calc = c;
        }

        public void Work(string a, string b)
        {
            Console.Out.WriteLine(calc.Eval(a, b));
        }
    }