using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _1A2B_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int c = 0;
            while (c == 0)
            {
                Random rnd = new Random();
                int a = 0, b, temp;
                var Input = new List<int>();
                var topic = new List<int>();
                Console.WriteLine("歡迎來到 1A2B 猜數字的遊戲～\r\n------");

                for (int i = 0; i < 4; i++)
                {
                    do
                    {
                        temp = rnd.Next(0, 10);
                    } while (topic.IndexOf(temp) != -1);
                    topic.Add(temp);
                }
                Console.Write("電腦挑出的數字為:");
                foreach (int item in topic)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
                while (a < 4)
                {
                re: Console.Write("請輸入 4 個數字:");
                    string n = Console.ReadLine();
                    a = 0;
                    b = 0;
                    Input.Clear();

                    foreach (var item in n.ToCharArray())
                    {
                        if (item < '0' || item > '9')
                        {
                            Console.WriteLine("請勿輸入數字以外的字元!!!");
                            goto re;
                        }
                        if (Input.IndexOf(int.Parse(item.ToString())) != -1)
                        {
                            Console.WriteLine("請勿輸入重複數字!!!");
                            goto re;
                        }
                        Input.Add(int.Parse(item.ToString()));

                    }
                    if (Input.Count() != 4)
                    {
                        Console.WriteLine("輸入的字數不正確!!!");
                        goto re;
                    }

                    //提取輸入數字
                    for (int i = 0; i < topic.Count; i++)
                    {
                        if (topic[i] == Input[i])
                        {
                            a++;
                        }
                    }//計算A
                    if (a == 4)
                    {
                        Console.WriteLine($"判定結果是:{a}A{b}B");
                        Console.WriteLine("恭喜你！猜對了！！\r\n------");
                    }
                    else
                    {
                        var AB = topic.Intersect(Input);//計算交集 A&B
                        b = AB.Count() - a;//減去重複計算的部分
                        Console.WriteLine($"判定結果是:{a}A{b}B\r\n------");
                    }
                }
            c: Console.WriteLine("你要繼續玩嗎？(y/n):");
                var yn = Console.ReadLine();
                if (yn == "n" || yn == "N")
                {
                    c = 1;
                    Console.WriteLine("遊戲結束，下次再來玩喔～\r\n");
                }
                else if (yn == "y" || yn == "Y")
                {
                    c = 0;
                }
                else
                {
                    Console.WriteLine("請輸入正確的字元");
                    goto c;
                }
            }
        }
    }
}
