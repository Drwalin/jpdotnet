namespace lab2;

    public class Worker
    {
        private ICalculator calculator;

        public Worker(ICalculator calc)
        {
            this.calculator = calc;
        }

        public void Work(string a, string b)
        {
            Console.Out.WriteLine(calculator.Eval(a, b));
        }
}