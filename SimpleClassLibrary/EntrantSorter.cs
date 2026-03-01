using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassLibrary
{
	public static class EntrantSorter
	{
		public static int CompareByPointsDescending(Entrant a, Entrant b)
		{
			if (a.GetCompMark() < b.GetCompMark()) return 1;
			if (a.GetCompMark() > b.GetCompMark()) return -1;
			return 0;
		}

		public static int CompareByNameThenPoints(Entrant a, Entrant b)
		{
			int nameCompare = a.GetName().CompareTo(b.GetName());

			if (nameCompare != 0)
				return nameCompare;

			if (a.GetCompMark() < b.GetCompMark()) return 1;
			if (a.GetCompMark() > b.GetCompMark()) return -1;
			return 0;
		}

		public static void SortByPoints(Entrant[] arr)
		{
			Array.Sort(arr, CompareByPointsDescending);
			Console.WriteLine("Відсортований список за конкурсним балом:");
			
		}

		public static void SortByName(Entrant[] arr)
		{
			Array.Sort(arr, CompareByNameThenPoints);
			Console.WriteLine("Відсортований список за прізвищем і балом:");
			
		}
	}
}
