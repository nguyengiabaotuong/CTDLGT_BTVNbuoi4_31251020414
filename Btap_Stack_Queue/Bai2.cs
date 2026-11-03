using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Btap_Stack_Queue
{
    internal class Bai2
    {
        static void Main2()
        {
            // Đọc dòng 1 
            string line1 = Console.ReadLine();
            if (string.IsNullOrEmpty(line1)) return;
            // Đọc dòng 2 
            string[] tokens = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            // Dùng Stack kiểu long để chứa các con số và kết quả trung gian
            Stack<long> stack = new Stack<long>();
            foreach (string token in tokens)
            {
                // Nếu là toán tử
                if (token == "+" || token == "-" || token == "*")
                {
                    // Số b được Pop ra trước là toán hạng bên phải
                    long b = stack.Pop();
                    // Số a được Pop ra sau là toán hạng bên trái
                    long a = stack.Pop();
                    long result = 0;
                    if (token == "+") result = a + b;
                    else if (token == "-") result = a - b;
                    else if (token == "*") result = a * b;
                    // Đẩy kết quả tính được trở lại Stack
                    stack.Push(result);
                }
                else
                {
                    // Nếu là con số, ép kiểu sang long rồi đẩy vào Stack
                    stack.Push(long.Parse(token));
                }
            }
            // In ra phần tử cuối cùng còn sót lại trong Stack
            Console.WriteLine(stack.Pop());
        }
    }
}
