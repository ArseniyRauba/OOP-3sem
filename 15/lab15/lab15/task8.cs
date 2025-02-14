﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab15
{
    static partial class TPL
    {
        public static async Task task8()
        {

            List<Product> data = new();

            await Task.Run(() => data = GetProducts());
            Console.WriteLine("Task 8");

            foreach (var product in data)
            {
                Console.WriteLine(product);
            }
        }

        public static List<Product> GetProducts()
        {
            List<Product> list = new();

            using StreamReader sr = new("products.json");
            int cnt = 0;
            string json;
            while (!sr.EndOfStream && cnt++ < 200)
            {
                json = sr.ReadLine() ?? "";
                list.Add(JsonSerializer.Deserialize<Product>(json));
                Thread.Sleep(20);
            }

            return list;
        }
    }
}
