using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\跨域黑客\C#\linq pc\linqHw\product.csv";
            var read = new StreamReader(File.OpenRead(path));
            
            List<string> lines = new List<string>();
            List<string> tags = new List<string>();
            List<string> count = new List<string>();
            //List<string>
            while (!read.EndOfStream)
            {
                var data = read.ReadLine();
                var sp = data.Split(',');
                lines.Add(sp[0]);
                tags.Add(sp[1]);
                count.Add(sp[2]);
            }
            foreach (var d1 in lines)
            {
                Console.WriteLine(d1);
            }
            foreach (var d2 in tags)
            {
                Console.WriteLine(d2);
            }
            foreach (var d3 in count)
            {
                Console.WriteLine(d3);
            }
           



            Console.ReadLine();

            //1.計算所有商品的總價格

            //2.計算所有商品的平均價格

            //3.計算商品的總數量

            //4.計算商品的平均數量

            //5.找出哪一項商品最貴
            //6.找出哪一項商品最便宜
            //7.計算產品類別為 3C 的商品總價
            //8.計算產品類別為飲料及食品的商品價格
            //9.找出所有商品類別為食品，而且商品數量大於 100 的商品
            //10.找出各個商品類別底下有哪些商品的價格是大於 1000 的商品
            //11.呈上題，請計算該類別底下所有商品的平均價格
            //12.依照商品價格由高到低排序
            //13.依照商品數量由低到高排序
            //14.找出各商品類別底下，最貴的商品
            //15.找出各商品類別底下，最貴的商品
            //16.找出價格小於等於 10000 的商品
            //17.製作一頁 4 筆總共 5 頁的分頁選擇器

        }

        static List<Product> CreateList() 
        {
            
            //商品編號,商品名稱,商品數量,價格,商品類別
            return new List<Product>
            {
               // new Product {ProductID = , ProductName = "", ProductCount = , ProductPrice = , ProductClass = "" }
            };
        }
    }
}
