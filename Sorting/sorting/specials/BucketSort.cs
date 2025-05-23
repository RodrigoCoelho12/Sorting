namespace Sorting.sorting.specials
{
    class BucketSort
    {
        public static int[] Sorting(int[] array)
        {
            int n = array.Length;
            if (n <= 0) return array;

            int max = array[0], min = array[0];
            foreach (int num in array)
            {
                if (num > max) max = num;
                if (num < min) min = num;
            }

            int bucketCount = 10;
            List<int>[] buckets = new List<int>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
                buckets[i] = new List<int>();

            foreach (int num in array)
            {
                int index = (num - min) * (bucketCount - 1) / (max - min + 1);
                buckets[index].Add(num);
            }

            int k = 0;
            foreach (var bucket in buckets)
            {
                bucket.Sort();
                foreach (int num in bucket)
                    array[k++] = num;
            }

            return array;
        }
    }
}
