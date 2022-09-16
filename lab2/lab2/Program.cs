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
        }

        internal class Stck
        {
            private const string container = "List";
            private static int objectCounter;
            private readonly int id;
            private List<float> stack;

            //private Stck()
            //{
            //    Random random = new Random();
            //    this.id = random.Next(100)%3;
            //}
            static Stck()
            {
                objectCounter = 0;
                objectCounter++;
            }

            public Stck()
            {
                this.stack = new List<float>(1);
                objectCounter = 0;
                objectCounter++;
                Random random = new Random();
                this.id = random.Next(-100, 100);
            }

            public Stck(float firstItem)
            {
                this.stack = new List<float>(1)
            {
                firstItem
            };
                objectCounter++;
            }

            public Stck(int size, float firstItem)
            {
                this.stack = new List<float>(size)
                {
                    firstItem
                };
                objectCounter++;
            }

            public string getContainter => container;
            public int getId => this.id;

            public int getObejectCounter => objectCounter;

            public float TopValue
            {
                get => this.stack[^1];
                set
                {
                    float top = value;
                    this.stack.Add(value);
                }
            }

            public List<float> wholeStack => this.stack;

            public static void ShowInfo()
            {
                Console.WriteLine("class information:\n" +
                    "total amount of class instances: " + objectCounter
                    + "\ncontaner: " + container);
            }
        }
    }
}