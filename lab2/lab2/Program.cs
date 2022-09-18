using System;
using System.Collections.Generic;

namespace lab2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stck s = new Stck(4);
            Console.WriteLine(s.TopValue);
            Stck s2 = new Stck(4, 5.0);
            Console.WriteLine(s2[0]);
        }

        internal class Stck
        {
            private const string container = "List";
            private static int objectCounter;
            private readonly int id;
            private List<double> stack;

            static Stck()
            {
                objectCounter = 0;
                objectCounter++;
            }

            public Stck(double firstItem)
            {
                this.stack = new List<double>(1)
            {
                firstItem
            };
                objectCounter++;
            }

            public Stck(int size, double firstItem)
            {
                this.stack = new List<double>(size)
                {
                    firstItem
                };
                objectCounter++;
            }

            public Stck()
            {
                this.stack = new List<double>(1);
                objectCounter = 0;
                objectCounter++;
                Random random = new Random();
                this.id = random.Next(-100, 100);
            }

            private Stck(int id)
            {
                Random random = new Random();
                this.id = random.Next(100) % 3 + id;
            }

            public string getContainter => container;
            public int getId => this.id;

            public int getObejectCounter => objectCounter;

            public double TopValue
            {
                get => this.stack[^1];
                set
                {
                    double top = value;
                    this.stack.Add(value);
                }
            }

            public List<double> WholeStack => this.stack;

            public double this[int index]
            {
                get => this.stack[index];
                set => this.stack[index] = value;
            }

            public static void ShowInfo()
            {
                Console.WriteLine("class information:\n" +
                    "total amount of class instances: " + objectCounter
                    + "\ncontaner: " + container);
            }
        }
    }
}