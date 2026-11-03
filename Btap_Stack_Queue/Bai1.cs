using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Btap_Stack_Queue
{
    internal class Bai1
    {
        static void Main1()
        {
            // Đọc chuỗi đầu vào và xóa các khoảng trắng thừa ở hai đầu (nếu có)
            string s = Console.ReadLine();
            if (string.IsNullOrEmpty(s)) return;
            s = s.Trim();
            // Sử dụng Stack để lưu trữ các dấu ngoặc mở
            Stack<char> stack = new Stack<char>();
            // Duyệt qua từng ký tự trong chuỗi
            foreach (char c in s)
            {
                // Nếu là dấu ngoặc mở, đẩy vào ngăn xếp
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                // Nếu là dấu ngoặc đóng
                else if (c == ')' || c == ']' || c == '}')
                {
                    // Nếu ngăn xếp rỗng mà lại có ngoặc đóng -> Sai thứ tự
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    // Lấy dấu ngoặc mở gần nhất ra khỏi ngăn xếp để kiểm tra
                    char top = stack.Pop();
                    // Kiểm tra xem chúng có khớp nhau không
                    if ((c == ')' && top != '(') ||
                        (c == ']' && top != '[') ||
                        (c == '}' && top != '{'))
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            // Kết thúc vòng lặp, nếu ngăn xếp rỗng thì tất cả các ngoặc đã được đóng đúng
            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
