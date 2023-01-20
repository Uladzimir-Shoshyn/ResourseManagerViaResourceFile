using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using ResourseFile = ConsoleApp.Resource1;

namespace ConsoleApp
{
    internal class Program
    {
        private const int IterrationCount = 20;
        private static readonly ResourceManager ResourceManager = new ResourceManager(typeof(ConsoleApp.Resource1));
        private static readonly CultureInfo cultureInfo = new CultureInfo("en-US");
        private static readonly Stopwatch stopwatch = new Stopwatch();
        private static readonly List<long> durationRsourseManager = new List<long>();
        private static readonly List<long> durationResourseFile = new List<long>();

        static void Main(string[] args)
        {
            ResourseFile.Culture = cultureInfo;

            for (int i = 0; i < IterrationCount; i++)
            {
                stopwatch.Start();

                Console.WriteLine(ResourceManager.GetString("Key1", cultureInfo));
                Console.WriteLine(ResourceManager.GetString("Key2", cultureInfo));
                Console.WriteLine(ResourceManager.GetString("Key3", cultureInfo));
                Console.WriteLine(ResourceManager.GetString("Key4", cultureInfo));
                Console.WriteLine(ResourceManager.GetString("Key5", cultureInfo));
                Console.WriteLine(ResourceManager.GetString("Key6", cultureInfo));
                Console.WriteLine(ResourceManager.GetString("Key7", cultureInfo));
                Console.WriteLine(ResourceManager.GetString("Key8", cultureInfo));
                Console.WriteLine(ResourceManager.GetString("Key9", cultureInfo));
                Console.WriteLine(ResourceManager.GetString("Key10", cultureInfo));
                Console.WriteLine(ResourceManager.GetString("Key11", cultureInfo));
                Console.WriteLine(ResourceManager.GetString("Key12", cultureInfo));

                stopwatch.Stop();

                durationRsourseManager.Add(stopwatch.ElapsedMilliseconds);
            }            

            stopwatch.Restart();            

            for (int i = 0; i < IterrationCount; i++)
            {
                stopwatch.Start();
                
                Console.WriteLine(ResourseFile.Key1);
                Console.WriteLine(ResourseFile.Key2);
                Console.WriteLine(ResourseFile.Key3);
                Console.WriteLine(ResourseFile.Key4);
                Console.WriteLine(ResourseFile.Key5);
                Console.WriteLine(ResourseFile.Key6);
                Console.WriteLine(ResourseFile.Key7);
                Console.WriteLine(ResourseFile.Key8);
                Console.WriteLine(ResourseFile.Key9);
                Console.WriteLine(ResourseFile.Key10);
                Console.WriteLine(ResourseFile.Key11);
                Console.WriteLine(ResourseFile.Key12);

                stopwatch.Stop();

                durationResourseFile.Add(stopwatch.ElapsedMilliseconds);
            }

            PrintResult();

            Console.ReadLine();
        }

        private static void PrintResult()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Itteration count: {IterrationCount}");
            Console.WriteLine();

            StringBuilder strResult = new StringBuilder();
            Console.WriteLine($"========Resource Manager===========");
            durationRsourseManager.ForEach(s => strResult.Append($"{s} ms; "));

            Console.WriteLine(strResult.ToString());
            Console.WriteLine($"Average duration: {durationRsourseManager.Average()} ms.");

            Console.WriteLine($"===============================");


            Console.WriteLine($"========Resource File===========");
            strResult = new StringBuilder();
            durationResourseFile.ForEach(s => strResult.Append($"{s} ms; "));
            Console.WriteLine(strResult.ToString());
            Console.WriteLine($"Average duration: {durationResourseFile.Average()} ms.");
            Console.WriteLine($"===============================");
        }
    }
}
