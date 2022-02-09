using SpaghettiMaker.Common.Dishes;
using SpaghettiMaker.Logic;
using System.Diagnostics;

namespace SpaghettiMaker.ConApp
{
    public class Program
    {
        public static async Task Main()
        {
            Console.WriteLine("Prepare dinner...");
            Console.WriteLine();
            var watch = new Stopwatch();
            watch.Start();
            var start = DinnerMakerAsync.MakeAsync();
            watch.Stop();

            Console.WriteLine();
            Console.WriteLine($"Preparation took {watch.ElapsedMilliseconds / 1000} seconds");
       }
    }
}