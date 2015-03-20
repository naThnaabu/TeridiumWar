using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

namespace TeridiumRPG
{
    public static class GameOutput
    {
        public static int printMenu (string[] options, string header = "", string footer = "", string picture = "", string posttext = "")
        {
            Console.Clear ();
            if (picture != "") {
                Console.WriteLine (picture);
            }
            if (header != "") {
                Console.WriteLine (header);
            }
            foreach (string option in options) {
                string firstchar = option.Substring (0, 1);
                string lastpart = option.Substring (1, option.Length - 1);
                Console.WriteLine (@"({0}){1}", firstchar, lastpart);
            }
            if (footer != "") {
                Console.WriteLine (footer);
            }
            Console.WriteLine ();
            if (posttext != "") {
                Console.WriteLine (posttext);
            }
            ConsoleKeyInfo choiceKey = Console.ReadKey (true);
            string shopchoice = choiceKey.KeyChar.ToString ().ToLower ();
            for (int i = 0; i < options.Length; i++) {
                string firstchar = options [i].Substring (0, 1).ToLower ();
                if (firstchar == shopchoice)
                    return i;
            }
            return 255;
        }

        public static int printTable (string[] rows, string[] columns, string decideText = "", string additionalInfo = "", string picture = "", int length = 100)
        {
            Console.Clear ();
            Console.WriteLine (decideText);
            Console.WriteLine ();
            Console.WriteLine (picture);
            for (int i = 1; i < length; i++) {
                Console.Write ("*");
            }
            Console.WriteLine ();
            string[] seperator = { ";" };
            int icolumns = columns.Length;
            int colwidth = length / icolumns;
            printTableRow (columns, colwidth);
            for (int i = 0; i < rows.Length; i++) {
                int y = i + 1;
                string row = rows [i];
                row = "(" + y + ")" + row;
                printTableRow (row.Split (seperator, StringSplitOptions.RemoveEmptyEntries), colwidth);
            }
            Console.WriteLine ("(E)xit");
            Console.WriteLine ();
            Console.WriteLine (additionalInfo);
            for (int i = 1; i < length; i++) {
                Console.Write ("*");
            }
            Console.Write ("\n");
            ConsoleKeyInfo choiceKey = Console.ReadKey (true);
            string choice = choiceKey.KeyChar.ToString ();
            if (choice == "E" | choice == "e") {
                return 255;
            } else {
                int ichoice;
                bool success = int.TryParse (choice, out ichoice);
                if (success) {
                    ichoice--;
                    return ichoice;
                } else {
                    return 255;
                }

            }
        }

        private static void printTableRow (string[] row, int colwidth)
        {
            foreach (string col in row) {
                if (col.Length > colwidth) {
                    Console.Write (col.Substring (0, colwidth - 1));
                } else if (col.Length == colwidth) {
                    Console.Write (col);
                } else {
                    int space = colwidth - col.Length;
                    int halfspace = space / 2;
                    for (int i = 0; i < halfspace; i++) {
                        Console.Write (" ");
                    }
                    Console.Write (col);
                    for (int i = 0; i < halfspace; i++) {
                        Console.Write (" ");
                    }
                }
            }
            Console.WriteLine ();
        }

        public static void printWait (string text)
        {
            Console.WriteLine (text);
            Console.WriteLine ("Press Enter to Continue");
            Console.ReadLine ();
        }
    }
}

