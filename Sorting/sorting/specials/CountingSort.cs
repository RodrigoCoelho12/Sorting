namespace Sorting.sorting.specials
{
    class CountingSort
    {
        public static int[] Sorting(int[] array)
        {
            int max = array[0];
            int min = array[0];
            foreach (int num in array)
            {
                if (num > max) max = num;
                if (num < min) min = num;
            }

            int range = max - min + 1;
            int[] count = new int[range];
            int[] output = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
                count[array[i] - min]++;

            for (int i = 1; i < range; i++)
                count[i] += count[i - 1];

            for (int i = array.Length - 1; i >= 0; i--)
            {
                output[count[array[i] - min] - 1] = array[i];
                count[array[i] - min]--;
            }

            return output;
        }
    }
}
