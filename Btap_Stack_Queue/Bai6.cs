using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Btap_Stack_Queue
{
    internal class Bai6
    {
        static void Main()
        {
            // Đọc dòng 1 lấy số lượng cột n
            string line1 = Console.ReadLine();
            if (string.IsNullOrEmpty(line1)) return;
            int n = int.Parse(line1.Trim());
            // Đọc dòng 2 chứa các chiều cao, dùng bộ lọc khoảng trắng an toàn
            string[] tokens = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            long[] h = new long[n];
            for (int i = 0; i < n; i++)
            {
                h[i] = long.Parse(tokens[i]);
            }
            // Stack lưu TỌA ĐỘ (chỉ số i) của các cột, KHÔNG lưu chiều cao
            Stack<int> stack = new Stack<int>();
            long maxArea = 0;
            // Chạy từ 0 đến n (cố tình chạy đến n để ép các cột còn lại trong Stack trút hết ra)
            for (int i = 0; i <= n; i++)
            {
                // Cột ảo ở vị trí n có chiều cao = 0, để đảm bảo bé hơn mọi cột trong Stack
                long currentHeight = (i == n) ? 0 : h[i];
                // Nếu cột hiện tại NGẮN HƠN cột trên đỉnh Stack
                // -> Cột trên đỉnh Stack đã bị "chặn đường", không thể mở rộng sang phải được nữa
                while (stack.Count > 0 && currentHeight < h[stack.Peek()])
                {
                    // Rút cột bị chặn ra để tính diện tích
                    int topIndex = stack.Pop();
                    long height = h[topIndex];
                    // Tính chiều rộng của hình chữ nhật
                    long width;
                    if (stack.Count == 0)
                    {
                        // Nếu Stack rỗng, nghĩa là cột này thấp nhất từ nãy đến giờ -> Rộng kéo dài từ đầu (0) đến i
                        width = i;
                    }
                    else
                    {
                        // Nếu Stack không rỗng, nó bị chặn bên trái bởi cột ngay dưới nó trong Stack
                        width = i - stack.Peek() - 1;
                    }
                    // Cập nhật diện tích lớn nhất
                    long area = height * width;
                    if (area > maxArea)
                    {
                        maxArea = area;
                    }
                }
                // Chiều cao tăng dần (hoặc bằng) thì cứ đẩy vị trí vào Stack
                stack.Push(i);
            }
            // In ra diện tích lớn nhất tìm được
            Console.WriteLine(maxArea);
        }
    }
}
