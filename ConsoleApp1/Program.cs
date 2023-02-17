using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = Createlist();
            string[] PageName = {"第一頁", "第二頁", "第三頁", "第四頁" , "第五頁"};
            
            //1.計算所有商品的總價格
            var sum = list.Skip(1).Sum((x) => decimal.Parse(x.ProductPrice));
            Console.WriteLine($"計算所有商品的總價格:{sum:C0}");

            //2.計算所有商品的平均價格
            var avg = list.Skip(1).Average((x) => decimal.Parse(x.ProductPrice));
            Console.WriteLine($"計算所有商品的平均價格:{avg:C0}");

            //3.計算商品的總數量
            var Prduct_count_sum = list.Skip(1).Sum((X) => decimal.Parse(X.ProductCount));
            Console.WriteLine($"商品的總數量:{Prduct_count_sum}");

            //4.計算商品的平均數量
            var count_avg = list.Skip(1).Average((x) => decimal.Parse(x.ProductCount));
            Console.WriteLine($"計算商品的平均數量:{count_avg:N0}\n");

            //5.找出哪一項商品最貴 [大]
            var product_max = list.Skip(1).Where((x) => decimal.Parse(x.ProductPrice) ==
            list.Skip(1).Max((y) => decimal.Parse(y.ProductPrice)));
            foreach (var item in product_max)
            {
                Console.WriteLine($"最昂貴的商品:{item.ProductName}");
            }
            //var product_max = list.Skip(1).OrderBy((x) => x.ProductPrice).Last();
            //Console.WriteLine(product_max.ProductName);

            //6.找出哪一項商品最便宜 遞增 [小] > 大
            var product_min = list.Skip(1).Where((x) => decimal.Parse(x.ProductPrice) ==
            list.Skip(1).Min((y) => decimal.Parse(y.ProductPrice)));
            foreach (var item in product_min)
            {
                Console.WriteLine($"最便宜的商品:{item.ProductName}");
            }
            //var product_min = list.Skip(1).OrderBy((x) => x.ProductPrice).First();
            //Console.WriteLine(product_min.ProductName);

            //7.計算產品類別為 3C 的商品總價
            var _3cSum = list.Skip(1).Where((x) => x.ProductClass == "3C").Sum((x) => decimal.Parse(x.ProductPrice));
            Console.WriteLine($"\n計算產品類別為 3C 的商品總價:{_3cSum:C0}");

            //8.計算產品類別為飲料及食品的商品總價
            var EatAndDrinkSum = list.Skip(1).Where((x) => x.ProductClass == "飲料").
                Sum((x) => decimal.Parse(x.ProductPrice)) +
                list.Skip(1).Where((x) => x.ProductClass == "食品").
                Sum((x) => decimal.Parse((x.ProductPrice)));
            Console.WriteLine($"\n計算產品類別為飲料及食品的商品總價:{EatAndDrinkSum:C0}");

            //9.找出所有商品類別為食品，而且商品數量大於 100 的商品
            var Eat_Count100up = list.Skip(1).Where((x) => x.ProductClass == "食品").Where((x) => decimal.Parse(x.ProductCount) > 100m);
            Console.WriteLine("\n食品類, 商品數量大於100:");
            foreach ( var item in Eat_Count100up )
            {
                Console.WriteLine($"||{item.ProductName}");
            }

            //10.找出各個商品類別底下有哪些商品的價格是大於 1000 的商品
            Console.WriteLine("\n各個商品類別底下有哪些商品的價格是大於 1000 的商品");
            var EachClass_Price1000up = list.Skip(1).
                Where((x) => decimal.Parse(x.ProductPrice) > 1000m).
                GroupBy((x) => x.ProductClass);
            foreach (var item in EachClass_Price1000up)
            {
                Console.WriteLine($"{item.Key}類別");
                foreach (var vaule in item)
                {
                    Console.WriteLine($"{vaule.ProductName} ---{decimal.Parse(vaule.ProductPrice):C0}");
                }
                
            }

            //11.呈上題，請計算該類別底下所有商品的平均價格
            Console.WriteLine("\n該類別底下所有商品的平均價格:");
            foreach (var item in EachClass_Price1000up)
            { 
                var Price1000up_Avg = item.Average((x) => decimal.Parse(x.ProductPrice));
                Console.WriteLine($"{item.Key}類別 ---- {Price1000up_Avg:C0}");
            }

            //12.依照商品價格由高到低排序
            Console.WriteLine("\n依照商品價格由【高】>【低】排序");
            var Price_HighToLow = list.Skip(1).OrderByDescending((x) => decimal.Parse(x.ProductPrice));
            foreach (var item in Price_HighToLow)
            {
                Console.WriteLine($"{item.ProductName} ---{decimal.Parse(item.ProductPrice):C0}");
            }

            //13.依照商品數量由低到高排序
            Console.WriteLine("\n依照商品數量由【低】>【高】排序");
            var Price_LowToHigh = list.Skip(1).OrderBy((x) => decimal.Parse(x.ProductPrice));
            foreach (var item in Price_LowToHigh)
            {
                Console.WriteLine($"{item.ProductName} ---{decimal.Parse(item.ProductPrice):C0}");
            }


            var Product_GroupByClass = list.Skip(1).GroupBy((x) => x.ProductClass); // GroupBy 分組

            //14.找出各商品類別底下，最貴的商品
            Console.WriteLine("\n各商品類別底下，最貴的商品");
            foreach (var item in Product_GroupByClass)
            {
                var MaxPriceByGroup = item.Where((x) => decimal.Parse(x.ProductPrice) == 
                item.Max((y) => decimal.Parse(y.ProductPrice)));
                
                foreach (var vaule in MaxPriceByGroup)
                {
                    Console.Write($"【{item.Key}】裡最貴的商品");
                    Console.WriteLine($"---{vaule.ProductName} ---{decimal.Parse(vaule.ProductPrice)}");
                }

            }

            //15.找出各商品類別底下，最便宜的商品
            Console.WriteLine("\n各商品類別底下，最便宜的商品");
            foreach (var item in Product_GroupByClass)
            {
                var MinPriceByGroup = item.Where((x) => decimal.Parse(x.ProductPrice) ==
                item.Min((y) => decimal.Parse(y.ProductPrice)));

                foreach (var vaule in MinPriceByGroup)
                {
                    Console.Write($"【{item.Key}】裡最便宜的商品");
                    Console.WriteLine($"---{vaule.ProductName} ---{decimal.Parse(vaule.ProductPrice)}");
                }

            }

            //16.找出價格小於等於 10000 的商品
            Console.WriteLine("價格小於等於 10000 的商品");
            var Price_lowEQ10000 = list.Skip(1).Where((x) => int.Parse(x.ProductPrice) <= 10000);
            foreach (var item in Price_lowEQ10000)
            {
                Console.WriteLine($"{item.ProductName}  --{item.ProductPrice}");
            }

            //17.製作一頁 4 筆總共 5 頁的分頁選擇器
            //商品編號,商品名稱,商品數量,價格,商品類別
            
            int n = 0;
            while (n <= 5)
            {
                foreach (var item in list.Take(1))
                {
                    Console.WriteLine("==========================================================================");
                    Console.WriteLine($"||{item.ProductID, 4}|| {item.ProductName, 20} || {item.ProductCount,2} || {item.ProductPrice,4} || {item.ProductClass,4} ||");
                    Console.WriteLine("==========================================================================");
                }
                if (n >= 0 && n < 5)
                {
                    foreach (var item in list.Skip(1).Skip(n * 4).Take(4))
                    {
                        int Name_key = 24, Class_key = 8;
                        int chineseCharacters = new Regex(@"[^\u4e00-\u9fa5]").Replace(item.ProductName, "").Length;
                        Name_key = Name_key - chineseCharacters;
                        chineseCharacters = new Regex(@"[^\u4e00-\u9fa5]").Replace(item.ProductClass, "").Length;
                        Class_key = Class_key - chineseCharacters;                   
                        Console.WriteLine($"||  {item.ProductID.PadLeft(4)}  || {item.ProductName.PadLeft(Name_key)} || {item.ProductCount, 8} || {item.ProductPrice, 6} || {item.ProductClass.PadLeft(Class_key)} ||");
 
                    }
                }
                Console.WriteLine($"================================={PageName[n]}===================================");
                Console.WriteLine("             請輸入數字換頁(1, 2, 3, 4, 5) (Y/y) 下一頁  (N/n) 前一頁");
                string Page = Console.ReadLine();
                if (Page == "y" || Page == "Y")
                {
                    n++;
                }
                else if (Page == "n" || Page == "N")
                {
                    n--;
                }
                else if (Page == "1")
                {
                    n = 0;
                }
                else if (Page == "2")
                {
                    n = 1;
                }
                else if (Page == "3")
                {
                    n = 2;
                }
                else if (Page == "4")
                {
                    n = 3;
                }
                else if (Page == "5")
                {
                    n = 4;
                }

                Console.Clear();

                if (n <= -1)
                {
                    
                    Console.WriteLine("=================================到底了===================================");
                    n = 0;
                }
                else if (n >= 5)
                {
                    Console.WriteLine("=================================到底了===================================");
                    n = 4;
                }
                
            }
            
            Console.ReadLine();
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
