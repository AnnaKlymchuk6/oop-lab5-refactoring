using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassLibrary
{
	public static class TuitionService
	{
		public static void SetTuitionForEntrants(Entrant[] entrants)
		{
			Console.WriteLine("\nВиберіть одиниці вимірювання для вартості навчання:");
			Console.WriteLine("1. За місяць");
			Console.WriteLine("2. За рік");
			Console.WriteLine("3. За весь період (40 місяців)");
			Console.Write("Ваш вибір: ");
			string choice = Console.ReadLine();

			foreach (var entrant in entrants)
			{
				double tuition;
				switch (choice)
				{
					case "1":
						Console.Write($"Введіть вартість навчання за місяць для {entrant.GetName()}: ");
						while (true)
						{
							if (double.TryParse(Console.ReadLine(), out tuition))
								break;

							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Введіть коректне число", ConsoleColor.Red);
							Console.ResetColor();
						}
						entrant.TuitionPerMonth = tuition;
						entrant.TuitionPerYear = tuition * 10;
						entrant.TuitionForPeriod = tuition * 40;
						break;

					case "2":
						Console.Write($"Введіть вартість навчання за рік для {entrant.GetName()}: ");
						while (true)
						{
							if (double.TryParse(Console.ReadLine(), out tuition))
								break;

							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Введіть коректне число", ConsoleColor.Red);
							Console.ResetColor();
						}
						entrant.TuitionPerYear = tuition;
						entrant.TuitionPerMonth = tuition / 10;
						entrant.TuitionForPeriod = entrant.TuitionPerMonth * 40;
						break;

					case "3":
						Console.Write($"Введіть вартість навчання за весь період (40 місяців) для {entrant.GetName()}: ");
						while (true)
						{
							if (double.TryParse(Console.ReadLine(), out tuition))
								break;

							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Введіть коректне число", ConsoleColor.Red);
							Console.ResetColor();
						}
						entrant.TuitionForPeriod = tuition;
						entrant.TuitionPerMonth = tuition / 40;
						entrant.TuitionPerYear = entrant.TuitionPerMonth * 10;
						break;

					default:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Невірний вибір! Спробуйте ще раз.", ConsoleColor.Red);
						Console.ResetColor();
						return;
				}
			}
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Вартість навчання успішно оновлена!", ConsoleColor.Green);
			Console.ResetColor();
		}
	}
}
