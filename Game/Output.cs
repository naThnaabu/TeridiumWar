using System;
using System.Collections.Generic;

namespace TeridiumRPG
{
	public static class GameOutput
	{
		public static int printMenu(string[] options, string header = "", string footer = "", string picture = "")
		{
			if(picture != ""){
				Console.WriteLine(picture);
			}
			if(header!=""){
				Console.WriteLine(header);
			}
			foreach(string option in options)
			{
				char firstchar = option.ToCharArray()[0];
				option = option.Substring(0, 1);
				Console.WriteLine(@"({0}){1}", firstchar, option);
			}
			if(footer!=""){
				Console.WriteLine(footer);
			}
			Console.WriteLine();
			ConsoleKeyInfo choiceKey = Console.ReadKey(true);
			string shopchoice = choiceKey.KeyChar.ToString();
			for(int i = 0; i < options.Length; i++)
			{
				char firstchar = options[i].ToCharArray()[0];
				if(firstchar==shopchoice)
					return i;
			}
			return 255;
		}

		public static int printTable(string[] rows, string[] columns, string decideText = "", string additionalInfo = "", string picture = "", int length = 52)
		{
			Console.WriteLine(decideText);
			Console.WriteLine();
			Console.WriteLine(picture);
			for(int i=1; i < length; i++)
			{
				Console.Write("*");
			}
			Console.Write("\n");
			int icolumns = columns.Length;
			int colwidth = length/icolumns;
			printTableRow(columns, colwidth);
			for(int i=0;i<rows.Length;i++)
			{
				int y = i + 1;
				string row = rows[i];
				row = "(" + y + ")" + row;
				printTableRow(row.Split(";"), colwidth);
			}
			Console.WriteLine("(E)xit");
			Console.WriteLine();
			Console.WriteLine(additionalInfo);
			for(int i=1; i < length; i++)
			{
				Console.Write("*");
			}
			Console.Write("\n");
			ConsoleKeyInfo choiceKey = Console.ReadKey(true);
			string choice = choiceKey.KeyChar.ToString();
			if(choice=="E" | choice=="e"){
				return 255;
			} else {
				int ichoice;
				bool success = int.TryParse(choice, ichoice);
				if(success)
					return ichoice;
				else
					return 255;
			}
		}

		private static void printTableRow(string[] row, int colwidth)
		{
			foreach(string col in row)
			{
				if(col.Length<colwidth)
				{
					Console.Write(col.Substring(0, colwidth));
				} else if(col.Length==colwidth){
					Console.Write(col);
				} else {
					int space = colwidth - col.Length;
					int halfspace = space/2;
					for(int i=0;i<halfspace;i++)
					{
						Console.Write(" ");
					}
					Console.Write(col);
					for(int i=0;i<halfspace;i++)
					{
						Console.Write(" ");
					}
				}
			}
		}

		public static void printWait(string text)
		{
			Console.WriteLine(text);
			Console.WriteLine("Press Enter to Continue");
			Console.ReadLine();
		}
	}
}

