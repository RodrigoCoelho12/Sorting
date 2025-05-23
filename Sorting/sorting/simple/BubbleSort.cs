namespace Sorting.sorting.simple
{
    class BubbleSort
    {
       public static int[] Sorting(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = n - 1; j > i; j--)
                {
                    UtilCountingTime.CountComp();
                    if (array[j] < array[j - 1])
                    {
                        int tmp = array[j];
                        UtilCountingTime.CountAtt();

                        array[j] = array[j - 1];
                        UtilCountingTime.CountAtt();

                        array[j - 1] = tmp;
                        UtilCountingTime.CountAtt();

                        UtilCountingTime.CountSwitch();
                    }
                }
            }

            return array;
        }
    }
}
