using System;

namespace ex00
{
    class Program
    {
		private static double i;
		private double percent;
		private static double	sumMonth;

		private static void DecreaseTerm(double sum, double rate, int term, int selectedMonth, double payment)
		{
			double max = sum;
			double summa = sum;
			var date = new DateTime(DateTime.Now.Year, selectedMonth, 1);
			i = rate / 12 / 100;
			Console.WriteLine("Дата		Платеж		ОД		Проценты	Остаток долга\n");
			for (int ind = 0; ind < 9; ind++)
			{
				sumMonth = ((summa) * i * Math.Pow((1 + i), term)) / (Math.Pow((1 + i), term) - 1);
				var nextDate = date.AddMonths(1);
				double percent = (sum * rate * (nextDate - date).TotalDays) / (100 * (DateTime.IsLeapYear(date.Year) ? 366 : 365));
				max = sumMonth - percent;
				sum = sum - max;
				if (ind == (selectedMonth - 1))
				{
					sum -= payment;
				}
				string formatted = date.ToString("dd'.'MM'.'yyyy");
				Console.WriteLine($"{formatted}	{sumMonth:0.00} р.	{max:0.00} р.	{percent:0.00} р.	{sum:0.00} р.");
				date = nextDate;
			}
		}
		private static void CreditMethod(double sum, double rate, int term, int selectedMonth, double payment)
		{
			DecreaseTerm(sum, rate, term, selectedMonth, payment);
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
