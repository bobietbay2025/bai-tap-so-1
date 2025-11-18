using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai1
{
    class PTB1
    {
        protected double a;
        protected double b;

        public PTB1(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public virtual void Giai()
        {
            if (a == 0)
            {
                if (b == 0)
                    Console.WriteLine("Phuong trinh vo so nghiem.");
                else
                    Console.WriteLine("Phuong trinh vo nghiem.");
            }
            else
            {
                double x = -b / a;
                Console.WriteLine("Nghiem cua phuong trinh bac 1: x = " + x);
            }
        }
    }

    class PTB2 : PTB1
    {
        private double c;

        public PTB2(double a, double b, double c)
            : base(a, b)
        {
            this.c = c;
        }

        public override void Giai()
        {
            if (a == 0)
            {
                Console.WriteLine("Phuong trinh tro thanh bac 1:");
                base.Giai();
                return;
            }

            double delta = b * b - 4 * a * c;

            if (delta < 0)
            {
                Console.WriteLine("Phuong trinh vo nghiem.");
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("Phuong trinh co nghiem kep x = " + x);
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine("Phuong trinh co 2 nghiem:");
                Console.WriteLine("x1 = " + x1);
                Console.WriteLine("x2 = " + x2);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Nhap b: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Nhap c: ");
            double c = double.Parse(Console.ReadLine());

            PTB2 pt = new PTB2(a, b, c);
            pt.Giai();

            Console.ReadLine();
        }
    }
}