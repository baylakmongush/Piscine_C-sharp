using System;

namespace ex00
{
    class Program
    {
		private double rateMonth;
		private double percent;

		private void DecreaseSum()
		{

		}

		private void DecreaseTerm()
		{

		}

		private void CreditMethod(double sum, double rate, int term, int selectedMonth, double payment)
		{
			rateMonth = rate / 12 / 100;
			percent = (sum * rateMonth ) 
		}
	
        static void Main(string[] args)
        {
            if (args.Length == 5)
			{
				double sum = double.Parse(args[0]);
				double rate = double.Parse(args[1]);
				int term = int.Parse(args[2]);
				int selectedMonth = int.Parse(args[3]);
				double payment = double.Parse(args[4]);
				CreditMethod(sum, rate, term, selectedMonth, payment);
			}
			else
			{
				Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
			}
        }
    }
}
