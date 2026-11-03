using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Btap_Stack_Queue
{
    internal class Bai3
    {
        static void Main3()
        {
            // Đọc chuỗi đầu vào
            string s = Console.ReadLine();
            if (string.IsNullOrEmpty(s)) return;
            // Xóa khoảng trắng 2 đầu nếu có
            s = s.Trim();
            Stack<char> stack = new Stack<char>();
            // Duyệt qua từng ký tự trong chuỗi s
            foreach (char c in s)
            {
                // Nếu Stack có phần tử và ký tự trên cùng của Stack giống ký tự đang xét
                if (stack.Count > 0 && stack.Peek() == c)
                {
                    // Trùng nhau thì triệt tiêu
                    stack.Pop();
                }
                else
                {
                    // Nếu không giống, hoặc Stack đang rỗng, thì đẩy ký tự hiện tại vào Stack
                    stack.Push(c);
                }
            }
            // Kết thúc vòng lặp, kiểm tra Stack
            if (stack.Count == 0)
            {
                Console.WriteLine("EMPTY"); // Nếu rỗng thì in EMPTY theo đề yêu cầu
            }
            else
            {
                // Do đặc tính LIFO (Vào sau ra trước), các ký tự lấy ra từ Stack sẽ bị ngược
                // Phải lật ngược mảng lại rồi mới ghép thành chuỗi kết quả
                char[] result = stack.ToArray();
                Array.Reverse(result);
                Console.WriteLine(new string(result));
            }
        }
    }
}
