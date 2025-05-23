using System.Diagnostics;

namespace Sorting.utils
{
    class UtilCountingTime
    {
       private static Stopwatch stopwatch = new Stopwatch();

        public static long Comparisons { get; private set; }
        public static long Switches { get; private set; }
        public static long Attributions { get; private set; }

        public static void StartCount()
        {
            Comparisons = 0;
            Switches = 0;
            Attributions = 0;
            stopwatch.Restart();
        }

        public static void EndCount()
        {
            stopwatch.Stop();
        }

        public static void CountComp()
        {
            Comparisons++;
        }

        public static void CountSwitch()
        {
            Switches++;
        }

        public static void CountAtt()
        {
            Attributions++;
        }

        public static void PrintCount()
        {
            Console.WriteLine("\n===Execução===");
            Console.WriteLine($"Tempo: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Comparações: {Comparisons}");
            Console.WriteLine($"Trocas: {Switches}");
            Console.WriteLine($"Atribuições: {Attributions}");
            Console.WriteLine("===============================\n");
        }

    }


}

