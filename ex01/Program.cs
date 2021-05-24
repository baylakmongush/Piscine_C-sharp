using System;
using System.IO;

namespace ex01
{
    class Program
    {
		public static int Calculate(string s, string t)
        {
            var bounds = new { Height = s.Length + 1, Width = t.Length + 1 };

            int[,] matrix = new int[bounds.Height, bounds.Width];

            for (int height = 0; height < bounds.Height; height++) { matrix[height, 0] = height; };
            for (int width = 0; width < bounds.Width; width++) { matrix[0, width] = width; };

            for (int height = 1; height < bounds.Height; height++)
            {
                for (int width = 1; width < bounds.Width; width++)
                {
                    int cost = (s[height - 1] == t[width - 1]) ? 0 : 1;
                    int insertion = matrix[height, width - 1] + 1;
                    int deletion = matrix[height - 1, width] + 1;
                    int substitution = matrix[height - 1, width - 1] + cost;

                    int distance = Math.Min(insertion, Math.Min(deletion, substitution));

                    if (height > 1 && width > 1 && s[height - 1] == t[width - 2] && s[height - 2] == t[width - 1])
                    {
                        distance = Math.Min(distance, matrix[height - 2, width - 2] + cost);
                    }

                    matrix[height, width] = distance;
                }
            }
            return matrix[bounds.Height - 1, bounds.Width - 1];
        }

		private static void Result(string[] arrayName)
		{
			int notFound = 0;
			Console.WriteLine("Enter name:");
			string name = Console.ReadLine();
			if (name == "")
			{
				Console.WriteLine("Your name was not found.");
				return ;
			}
			int i = 0;
			int j = 0;
			string someName = null;
			while (j < arrayName.Length)
			{
				i = Calculate(name, arrayName[j]);
				if (i == 0)
				{
					Console.WriteLine($"Hello, {arrayName[j]}");
					notFound = 1;
					break ;
				}
				j++;
			}
			if (notFound == 0)
			{
				i = 0;
				j = 0;
				while (j < arrayName.Length)
				{
					i = Calculate(name, arrayName[j]);
					if (i <= 2)
					{
						someName = arrayName[j];
						Console.WriteLine($"Did you mean {someName}? Y/N");
						string answer = Console.ReadLine();
						if (answer == "Y" || answer == "y")
						{
							Console.WriteLine($"Hello, {someName}!");
							return ;
						}
						else if (answer == "N" || answer == "n")
						{
							j++;
							continue ;
						}
						else
						{
							Console.WriteLine("Your name was not found.");
							return ;
						}
					}
					j++;
				}
			}
		}

        private static void	Main(string[] args)
        {
            string pathFile = "us.txt";
			if (File.Exists(pathFile))
			{
				string[] arrayName = File.ReadAllLines(pathFile);
				Result(arrayName);
			}
			else
				Console.Write("No such file!");
        }
    }
}
