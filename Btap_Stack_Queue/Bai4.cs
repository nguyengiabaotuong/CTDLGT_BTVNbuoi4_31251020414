using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Btap_Stack_Queue
{
    internal class Bai4
    {
        static void Main4()
        {
            // Đọc số nguyên n từ đầu vào
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) return;
            // Ép kiểu sang int 
            int n = int.Parse(input.Trim());
            // Sử dụng Queue (hàng đợi) kiểu chuỗi (string)
            Queue<string> queue = new Queue<string>();
            // Bắt đầu với phần tử "1" 
            queue.Enqueue("1");
            // Khởi tạo StringBuilder để chứa kết quả in ra
            StringBuilder output = new StringBuilder();
            // Lặp đúng n lần để in ra n số nhị phân đầu tiên
            for (int i = 0; i < n; i++)
            {
                // Lấy phần tử đầu tiên trong hàng đợi ra 
                string x = queue.Dequeue();
                // Ghi x vào bộ đệm kết quả
                output.AppendLine(x);
                // Thêm x + "0" vào cuối hàng đợi
                queue.Enqueue(x + "0");
                // Thêm x + "1" vào cuối hàng đợi
                queue.Enqueue(x + "1");
            }
            // In toàn bộ kết quả ra màn hình cùng một lúc
            Console.Write(output.ToString());
        }
    }
}
