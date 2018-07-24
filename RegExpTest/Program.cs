using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace RegExpTest
{
    class RegexpTestCli
    {
        static void Main(string[] args)
        {
            var enc = Encoding.GetEncoding(1251);

            string filename;
            if (args.Length == 0)
            {
                Console.WriteLine("No Input file. \nFile: ");
                filename = Console.ReadLine();
            }
            else
            {
                filename = args[0];
            }

            StreamReader playlistFile;

            if (filename != null && File.Exists(filename))
            {
                playlistFile = new StreamReader(filename, enc);
            }
            else
            {
                Console.WriteLine("Error! File not found \nPress any key to exit");
                Console.ReadKey();
                return;
            }

            var strings = new List<string>();
            while (!playlistFile.EndOfStream)
            {
                strings.Add(playlistFile.ReadLine());
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Pattern :");
                //Console.Write("RR\\s+\\d{1,2}:\\d{2}\\s");

                string pattern = Console.ReadLine();
                Exit(pattern);


                try
                {
                    foreach (var str in strings)
                    {
                        var match = Regex.Match(str, pattern);
                        //var b = new StringBuilder();

                        if (match.Success)
                            Console.WriteLine(match.Value.ToCharArray());
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                Console.ReadKey();
            }
        }

        public static void Exit(string str)
        {
            if (String.IsNullOrEmpty(str) ||
                str.ToLower().Contains("exit") ||
                str.ToLower().Contains("quit"))
                Environment.Exit(1);
        }
    }
}