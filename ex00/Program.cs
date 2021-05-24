using System;

namespace ex00
{
    class Program
    {
		private static double i;
		private double percent;
		private static double	sumMonth;

		private static void DecreaseSum(double sum, double rate, int term, int selectedMonth, double payment)
		{
			var date = new DateTime(DateTime.Now.Year, selectedMonth, 1);
			for (int i = 0; i < term; i++)
			{
				double percent = (sum * rate * date) / 100 * (DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365);
				selectedMonth--;
				var date1 = new DateTime(DateTime.Now.Year, selectedMonth, 1);
				date = date - date1;
				Console.WriteLine("Дата				Платеж			ОД			Проценты			Остаток долга");
				//Console.WriteLine($"{}				Платеж			ОД			Проценты			Остаток долга");
			}
		}

		private static void DecreaseTerm()
		{
			
		}

		private static void CreditMethod(double sum, double rate, int term, int selectedMonth, double payment)
		{
			i = rate / 12 / 100;
			sumMonth = ((sum) * i * Math.Pow((1 + i), term)) / (Math.Pow((1 + i), term) - 1);
			Console.Write(sumMonth); 
			DecreaseSum(sum, rate, term, selectedMonth, payment);
		}
	
        private static void Main(string[] args)
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
