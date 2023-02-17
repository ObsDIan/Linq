using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = Createlist();
            //var path = @"product.csv";
            //var read = new StreamReader(path);

            //while (!read.EndOfStream)
            //{
            //    var data = read.ReadLine();
            //    var sp = data.Split(',');

            //    var product = new Product
            //    {
            //        ProductID = sp[0],
            //        ProductName = sp[1],
            //        ProductCount = sp[2],
            //        ProductPrice = sp[3],
            //        ProductClass = sp[4],
            //    };

            //    list.Add(product);
            //}

            ////1.計算所有商品的總價格
            //var sum = list.Skip(1).Sum((x) => decimal.Parse(x.ProductPrice));
            //Console.WriteLine($"計算所有商品的總價格:{sum:C0}");

            ////2.計算所有商品的平均價格
            //var avg = list.Skip(1).Average((x) => decimal.Parse(x.ProductPrice));
            //Console.WriteLine($"計算所有商品的平均價格:{avg:C0}");

            ////3.計算商品的總數量
            //var count = list.Skip(1).Count();
            //Console.WriteLine($"商品的總數量:{count}");

            ////4.計算商品的平均數量
            //var count_avg = list.Skip(1).Average((x) => decimal.Parse(x.ProductCount));
            //Console.WriteLine($"計算商品的平均數量:{count_avg:N0}");

            ////5.找出哪一項商品最貴 遞增 小 > [大]
            //var product_max = list.Skip(1).OrderBy((x) => x.ProductPrice).Last();
            //Console.WriteLine(product_max.ProductName);

            ////6.找出哪一項商品最便宜 遞增 [小] > 大
            //var product_min = list.Skip(1).OrderBy((x) => x.ProductPrice).First();
            //Console.WriteLine(product_min.ProductName);

            //7.計算產品類別為 3C 的商品總價
            var _3cSum = list.Skip(1).Where((x) => x.ProductClass == "3C" ).Sum((x) => decimal.Parse(x.ProductPrice));
            Console.WriteLine($"計算產品類別為 3C 的商品總價:{_3cSum:C0}");
            
            



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

        static List<Product> Createlist()
        {
            var list = new List<Product>();
            var path = @"product.csv";
            var open = new StreamReader(path);

            while (!open.EndOfStream)
            {
                var read = open.ReadLine();
                var data = read.Split(',');

                var product = new Product
                {
                    ProductID = data[0],
                    ProductName = data[1],
                    ProductCount = data[2],
                    ProductPrice = data[3],
                    ProductClass = data[4],
                };

                list.Add(product);
            }

            return list;
        }
    }
}
