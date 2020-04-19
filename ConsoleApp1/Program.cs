using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class Program {
        private static readonly string[] items = { "One", "Two" };
        private static readonly string fileText = "Test Texting One Example";
        private static readonly List<string> counts = new List<string>();
        private static int counter = 0;
        private static bool isExactCase = false;

        static void Main(string[] args) {
            //Test1();
        }

        private static void Test1() {
            foreach (string s in items) {
                int cnt = CountSubStrings(fileText, s);
                if (cnt > 0) {
                    string cs = cnt.ToString().PadLeft(5);
                    counts.Add(cs);
                    counter++;
                } else break;
            }

            Console.WriteLine($"counter: {counter}");
        }

        private static int CountSubStrings(string text, string substring) {
            var rnd = new Random();
            return rnd.Next(0, 2);
        }
    }
}
