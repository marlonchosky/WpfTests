using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2 {
    class Program {
        static void Main(string[] args) {
            var dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");
            var imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

            foreach (var f in imageFiles) {
                Console.WriteLine($"FullName: {f.FullName}");
            }

            Console.ReadLine();
        }
    }
}
