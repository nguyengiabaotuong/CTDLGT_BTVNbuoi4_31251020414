using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Btap_Stack_Queue
{
    internal class Bai5
    {
        static void Main5()
        {
            // Đọc dòng 1 lấy n và k
            string[] line1 = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (line1.Length < 2) return;
            int n = int.Parse(line1[0]);
            int k = int.Parse(line1[1]);
            // Đọc dòng 2 lấy mảng a
            string[] line2 = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(line2[i]);
            }
            long totalTime = 0; // Dùng long để chống tràn nếu n và a[i] quá lớn
            // Duyệt 1 vòng duy nhất để cộng dồn thời gian
            for (int i = 0; i < n; i++)
            {
                if (i <= k)
                {
                    // Người đứng trước hoặc chính là người k
                    totalTime += Math.Min(a[i], a[k]);
                }
                else
                {
                    // Người đứng sau người k (bị mất lượt ở vòng cuối)
                    totalTime += Math.Min(a[i], a[k] - 1);
                }
            }
            // In kết quả
            Console.WriteLine(totalTime);
        }
    }
}
