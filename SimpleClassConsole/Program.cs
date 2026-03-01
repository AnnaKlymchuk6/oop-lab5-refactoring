using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleClassLibrary;

namespace SimpleClassConlsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Виконала: Климчук А.Б. групи ІПЗ-24-2[2]");
            Console.ResetColor();

            Entrant[] entrants = null;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n===== МЕНЮ =====");
                Console.ResetColor();
                Console.WriteLine("1. Ввести дані абітурієнтів");
                Console.WriteLine("2. Вивести усіх абітурієнтів");
                Console.WriteLine("3. Вивести найвищий та найнижчий конкурсний бал");
                Console.WriteLine("4. Відсортувати за спаданням конкурсного балу");
                Console.WriteLine("5. Відсортувати за прізвищем (якщо прізвище однакове, то за конкурсним балом)");
                Console.WriteLine("6. Ввести варість навчання");
                Console.WriteLine("7. Вивести варість навчання");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        entrants = ReadEntrantsArray();
                        break;

                    case "2":
                        if (entrants != null)
                            PrintEntrants(entrants);
                        else
                            ShowMessage("Спочатку введіть дані!", ConsoleColor.Red);
                        break;

                    case "3":
                        if (entrants != null)
                        {
                            GetEntrantsInfo(entrants, out double max, out double min);
                            ShowMessage($"Найвищий конкурсний бал: {max:F2}", ConsoleColor.DarkCyan);
                            ShowMessage($"Найнижчий конкурсний бал: {min:F2}", ConsoleColor.Yellow);
                        }
                        else
                            ShowMessage("Спочатку введіть дані!", ConsoleColor.Red);
                        break;

                    case "4":
                        if (entrants != null)
                        {
							EntrantSorter.SortByPoints(entrants);
							PrintEntrants(entrants);
							ShowMessage("Відсортовано за конкурсним балом.", ConsoleColor.Blue);
                        }
                        else
                            ShowMessage("Спочатку введіть дані!", ConsoleColor.Red);
                        break;

                    case "5":
                        if (entrants != null)
                        {
							EntrantSorter.SortByName(entrants);
							PrintEntrants(entrants);
							ShowMessage("Відсортовано за іменем та балом.", ConsoleColor.Blue);
                        }
                        else
                            ShowMessage("Спочатку введіть дані!", ConsoleColor.Red);
                        break;

                    case "6":
                        if (entrants != null)
							TuitionService.SetTuitionForEntrants(entrants);
                        else
                            ShowMessage("Спочатку введіть дані!", ConsoleColor.Red);
                        break;
                    case "7":
                        if (entrants != null)
                            PrintTuitionInfo(entrants);
                        else
                            ShowMessage("Спочатку введіть дані!", ConsoleColor.Red);
                        break;

                    case "0":
                        ShowMessage("Програма завершена.", ConsoleColor.DarkGray);
                        return;

                    default:
                        ShowMessage("Невірний вибір. Спробуйте ще раз.", ConsoleColor.Red);
                        break;
                }
            }
        }

        public static Entrant[] ReadEntrantsArray()
        {
            int n;
            while (true)
            {
                Console.Write("Введіть кількість абітурієнтів: ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                    break;
                ShowMessage("Введіть додатне ціле число!", ConsoleColor.Red);
            }

            Entrant[] arr = new Entrant[n];

            for (int i = 0; i < n; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nАбітурієнт #{i + 1}:");
                Console.ResetColor();

                Console.Write("Прізвище та ініціали: ");
                string name = Console.ReadLine();

                Console.Write("Ідентифікаційний код: ");
                string id = Console.ReadLine();

                double course;
                while (true)
                {
                    Console.Write("Бали за підготовчі курси: ");
                    if (double.TryParse(Console.ReadLine(), out course)) break;
                    ShowMessage("Введіть число!", ConsoleColor.Red);
                }

                double avg;
                while (true)
                {
                    Console.Write("Бал атестату: ");
                    if (double.TryParse(Console.ReadLine(), out avg)) break;
                    ShowMessage("Введіть число!", ConsoleColor.Red);
                }

                int count;
                while (true)
                {
                    Console.Write("Кількість ЗНО-предметів: ");
                    if (int.TryParse(Console.ReadLine(), out count) && count > 0) break;
                    ShowMessage("Введіть додатне число!", ConsoleColor.Red);
                }

                ZNO[] zno = new ZNO[count];
                for (int j = 0; j < count; j++)
                {
                    Console.Write($"Предмет {j + 1}: ");
                    string sub = Console.ReadLine();

                    int pts;
                    while (true)
                    {
                        Console.Write("Результати: ");
                        if (int.TryParse(Console.ReadLine(), out pts)) break;
                        ShowMessage("Введіть число!", ConsoleColor.Red);
                    }

                    zno[j] = new ZNO(sub, pts);
                }

                arr[i] = new Entrant(name, id, course, avg, zno);
            }

            ShowMessage("Введення завершено!", ConsoleColor.Green);
            return arr;
        }

        public static void PrintEntrant(Entrant e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Прізвище та ініціали: {e.GetName()}");
            Console.WriteLine($"ID: {e.GetIdNum()}");
            Console.WriteLine($"Підготовчі курси: {e.GetCoursePoints()}");
            Console.WriteLine($"Атестат: {e.GetAvgPoints()}");
            Console.WriteLine($"Конкурсний бал: {e.GetCompMark():F2}");
            Console.ResetColor();

            Console.WriteLine("ZNO:");
            foreach (var z in e.GetZNOResults())
            {
                Console.WriteLine($" - {z.GetSubject()}: {z.GetPoints()}");
            }

            Console.WriteLine($"Найкращий предмет: {e.GetBestSubject()}");
            Console.WriteLine($"Найгірший предмет: {e.GetWorstSubject()}");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Оплата за місяць: {e.TuitionPerMonth:F2} грн");
            Console.WriteLine($"Оплата за рік: {e.GetTuitionPerYear():F2} грн");
            Console.WriteLine($"Оплата за весь період: {e.GetTuitionFull():F2} грн");
            Console.ResetColor();

        }

        public static void PrintEntrants(Entrant[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n--- Абітурієнт #{i + 1} ---");
                Console.ResetColor();
                PrintEntrant(arr[i]);
            }
        }

        public static void GetEntrantsInfo(Entrant[] arr, out double max, out double min)
        {
            max = arr[0].GetCompMark();
            min = arr[0].GetCompMark();

            foreach (var e in arr)
            {
                double mark = e.GetCompMark();
                if (mark > max) max = mark;
                if (mark < min) min = mark;
            }
        }

        

        

        public static void PrintTuitionInfo(Entrant[] entrants)
        {
            Console.WriteLine("\nІнформація про вартість навчання абітурієнтів:\n");
            foreach (var entrant in entrants)
            {
                Console.WriteLine($"Ім'я: {entrant.GetName()}");
                Console.WriteLine($"Вартість за місяць: {entrant.TuitionPerMonth} грн");
                Console.WriteLine($"Вартість за рік (10 місяців): {entrant.TuitionPerYear} грн");
                Console.WriteLine($"Вартість за весь період (40 місяців): {entrant.TuitionForPeriod} грн\n");
            }
        }

        public static void ShowMessage(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
