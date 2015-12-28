using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTest
{
    class Program
    {
        static string path = @"E:\\Downloads";
        static void Main(string[] args)
        {
            Start();

        }

        private static void Start()
        {
            Console.WriteLine();
            Console.WriteLine("A for FileInfo B for EnumerateFiles. Q to exit");
            var key = Console.ReadKey(true);
            var s = new Stopwatch();
            s.Start();
            if (key.Key == ConsoleKey.A)
            {
                Console.WriteLine("Running file info.");
                for (int i = 0; i < 100; i++)
                {

                    RunFileInfo();
                }
            }

            else if(key.Key == ConsoleKey.B)
            {
                Console.WriteLine("Running EnumerateFiles.");
                for (int i = 0; i < 100; i++)
                {
                    RunOther();
                }
            }
            else if (key.Key == ConsoleKey.Q)
            {
                return;
            }
            s.Stop();
            TimeSpan ts = s.Elapsed;
            Console.WriteLine(String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10));
            Start();
        }

        private static void RunOther()
        {
            Console.Write(".");
            var di = new DirectoryInfo(path);
            var files = from f in di.EnumerateFiles()
                        select f;

            // Show results.
            foreach (var file in files)
            {
                var f = string.IsNullOrEmpty(file.Name);
            }

        }

        private static void RunFileInfo()
        {
            Console.Write(".");
            var di = new DirectoryInfo(path);

            var files = di.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var f = string.IsNullOrEmpty(file.Name);
            }
        }
    }
}
