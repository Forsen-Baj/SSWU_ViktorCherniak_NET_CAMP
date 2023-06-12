using Home_task_11_1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_11_2
{
    public static class ExternalSort
    {
        public static void SortFile(string filePath, int bucketSize, ISorter? sorter = null)
        {
            if (!File.Exists(filePath)) return;

            int kBuckets = SplitFileIntoBuckets(filePath, bucketSize, sorter);
            MergeBuckets(kBuckets);

            File.Copy("bucket0.txt", filePath, true);
            File.Delete("bucket0.txt");

        }

        private static int SplitFileIntoBuckets(string filePath, int bucketSize, ISorter? sorter)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                List<int> bucket = new List<int>();

                int n = 0;
                int kBuckets = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (n == bucketSize)
                    {
                        WriteBucket(kBuckets++, bucket, sorter);
                        bucket.Clear();
                        bucket.Add(Int32.Parse(line));
                        n = 1;
                    }
                    else
                    {
                        bucket.Add(Int32.Parse(line));
                        n++;
                    }
                }
                WriteBucket(kBuckets, bucket, sorter);
                return kBuckets;
            }
        }

        private static void WriteBucket(int kBuckets, List<int> bucket, ISorter? sorter)
        {
            if (sorter == null)
                bucket.Sort();
            else
                sorter.Sort(bucket);

            string filePath = $"bucket{kBuckets}.txt";
            var s = String.Join("\n", bucket);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(s);
            }
        }

        private static void MergeBuckets(int kBuckets)
        {
            for (int i = 1; i <= kBuckets; i++)
            {
                using (StreamWriter writer = new StreamWriter("temp.txt"))
                using (StreamReader reader1 = new StreamReader("bucket0.txt"))
                using (StreamReader reader2 = new StreamReader($"bucket{i}.txt"))
                {
                    string? line1 = reader1.ReadLine();
                    string? line2 = reader2.ReadLine();

                    //while (((line1 = reader1.ReadLine()) != null) && ((line1 = reader1.ReadLine()) != null))
                    while(true)
                    {
                        if (string.IsNullOrEmpty(line1) || string.IsNullOrEmpty(line2))
                        {
                            while (!string.IsNullOrEmpty(line1))
                            {
                                writer.WriteLine(line1);
                                line1 = reader1.ReadLine();
                            }
                            while (!string.IsNullOrEmpty(line2))
                            {
                                writer.WriteLine(line2);
                                line2 = reader2.ReadLine();
                            }
                            break;
                        }

                        //if (line1.CompareTo(line2) < 0)
                        if (int.Parse(line1).CompareTo(int.Parse(line2)) <= 0)
                        {
                            writer.WriteLine(line1);
                            line1 = reader1.ReadLine();
                        }
                        else
                        {
                            writer.WriteLine(line2);
                            line2 = reader2.ReadLine();
                        }
                    }
                }
                File.Delete($"bucket{i}.txt");
                File.Copy("temp.txt", "bucket0.txt", true);
                File.Delete("temp.txt");
            }
        }
    }
}
