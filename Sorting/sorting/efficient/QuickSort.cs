namespace Sorting.sorting.efficient
{
    class QuickSort
    {
        public static int[] Sorting(int[] array)
        {
            QuickSortRecursive(array, 0, array.Length - 1);
            return array;
        }

        private static void QuickSortRecursive(int[] array, int start, int end)
        {
            if (start < end)
            {
                UtilCountingTime.CountComp(); 
                int pivot = Particionar(array, start, end);
                QuickSortRecursive(array, start, pivot - 1);
                QuickSortRecursive(array, pivot + 1, end);
            }
        }

        private static int Partition(int[] array, int start, int end)
        {
            int pivot = array[end];
            UtilCountingTime.CountAtt();

            int i = start - 1;
            UtilCountingTime.CountAtt();

            for (int j = start; j < end; j++)
            {
                UtilCountingTime.CountComp();
                if (array[j] <= pivot)
                {
                    i++;
                    UtilCountingTime.CountAtt();

                    (array[i], array[j]) = (array[j], array[i]);
                    UtilCountingTime.CountSwitches();
                }
            }

            (array[i + 1], array[end]) = (array[end], array[i + 1]);
            UtilCountingTime.CountSwitches();

            return i + 1;
        }
    }
}
