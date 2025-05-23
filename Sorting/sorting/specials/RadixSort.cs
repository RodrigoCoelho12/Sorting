namespace Sorting.sorting.specials
{
    class RadixSort
    {
         public static int[] Sorting(int[] array)
        {
            int max = array[0];
            foreach (int num in array)
                if (num > max) max = num;

            for (int exp = 1; max / exp > 0; exp *= 10)
                CountingSortByDigit(array, exp);

            return array;
        }

        private static void CountingSortByDigit(int[] array, int exp)
        {
            int n = array.Length;
            int[] output = new int[n];
            int[] count = new int[10];

            for (int i = 0; i < n; i++)
                count[(array[i] / exp) % 10]++;

            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                int index = (array[i] / exp) % 10;
                output[count[index] - 1] = array[i];
                count[index]--;
            }

            for (int i = 0; i < n; i++)
                array[i] = output[i];
        }
    }
}
