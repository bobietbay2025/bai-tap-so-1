using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapcuoigio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<sinhvien> list = new List<sinhvien>();

            Console.WriteLine("so luong sinh vien: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nnhap sinhvien thu{i + 1}:");

                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("ten: ");
                string name = Console.ReadLine();

                Console.Write("tuoi: ");
                int age = int.Parse(Console.ReadLine());

                list.Add(new sinhvien()
                {
                    Id = id,
                    Name = name,
                    Age = age
                });
            }

            Console.WriteLine("\ndanh sach: ");
            foreach (var sv in list)
                Console.WriteLine($"{sv.Id} - {sv.Name} - {sv.Age}");

            Console.WriteLine("\nsinhvien co tuoi tu 15 - 18:");
            var ageQuery = list.Where(sv => sv.Age >= 15 && sv.Age <= 18);
            foreach (var sv in ageQuery)
                Console.WriteLine($"{sv.Id} - {sv.Name} - {sv.Age}");

            Console.WriteLine("\nsinh vien co ten bac dau bang chu A:");
            var nameA = list.Where(sv => sv.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase));
            foreach (var sv in nameA)
                Console.WriteLine($"{sv.Id} - {sv.Name} - {sv.Age}");

            Console.WriteLine("\ntong tuoi cua cac sinh vien:");
            Console.WriteLine(list.Sum(sv => sv.Age));

            Console.WriteLine("\nsinh vien lon tuoi nhat:");
            int maxAge = list.Max(sv => sv.Age);
            var maxList = list.Where(sv => sv.Age == maxAge);
            foreach (var sv in maxList)
                Console.WriteLine($"{sv.Id} - {sv.Name} - {sv.Age}");

            Console.WriteLine("\ndanh sach xep tuoi tang dan:");
            var sorted = list.OrderBy(sv => sv.Age);
            foreach (var sv in sorted)
                Console.WriteLine($"{sv.Id} - {sv.Name} - {sv.Age}");

            Console.ReadLine();
        }
    }
}
