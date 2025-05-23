namespace Sorting.sorting.efficient
{
    class MergeSort
    {
         public static int[] Sorting(int[] vet)
        {
            if (vet.Length <= 1)
                return vet;

            int middle = vet.Length / 2;
            int[] left = Sorting(vet[..middle]);
            int[] right = Sorting(vet[middle..]);

            return Merge(left, right);
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];

            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                    result[k++] = left[i++];
                else
                    result[k++] = right[j++];
            }

            while (i < left.Length)
                result[k++] = left[i++];
            while (j < right.Length)
                result[k++] = right[j++];

            return result;
        }
    }
}
