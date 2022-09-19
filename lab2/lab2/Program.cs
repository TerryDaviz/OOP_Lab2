using System;
using System.Collections.Generic;

namespace lab2
{
    public partial class Program
    {
        private static void Main(string[] args)
        {
            Stck st = new Stck(4);
            Console.WriteLine(st.TopValue);
            Stck st2 = new Stck(4, 5.0);
            Console.WriteLine(st2[0]);
            st2.RemoveFromStack();
            st2.AddTopValue(3.5);
            st2.AddTopValue(5.5);
            double newValue = 5.6;
            st2.ChangeTopValue(ref newValue);
            string strValue = "4,4";
            st2.AddStringValue(ref strValue);
            st2.AddConvertedCharValue('a', out double bro);
            st2.ShowStack();
            Stck st3 = new Stck();
            st3.CreateStack(5);

            Stck[] arr = new Stck[3] { st, st2, st3 };
            Stck maxStck = new Stck(0.0F);
            Stck minStck = new Stck(0.0F);
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].TopValue > maxStck.TopValue)
                {
                    maxStck = arr[i];
                }
            }
            Console.WriteLine("\n=================");
            Console.WriteLine("\nstack with max top value:");
            maxStck.ShowStack();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].TopValue < minStck.TopValue)
                {
                    minStck = arr[i];
                }
            }
            Console.WriteLine("\n=================");
            Console.WriteLine("\nstack with min top value: ");
            minStck.ShowStack();
            List<Stck> stacksWithNegatives = new List<Stck>();
            for (int i = 0; i < arr.Length; i++)
            {
                foreach (double x in arr[i].WholeStack)
                {
                    if (x < 0)
                    {
                        stacksWithNegatives.Add(arr[i]);
                    }
                }
            }
            Console.WriteLine("\n=============");
            Console.WriteLine("\nstacks with negative elements");
            foreach (Stck x in stacksWithNegatives)
            {
                Console.WriteLine("\n\n");
                x.ShowStack();
            }

            Console.WriteLine("Anonnymous type");
            var anon = new { TopValue = 5, Container = "List", Objectcounter = 5, Id = 12 };
            Console.WriteLine(anon.GetType());
        }

        public partial class Stck
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

            public string Containter => container;
            public int Id => this.id;

            public int ObejectCounter => objectCounter;

            public double TopValue
            {
                get => this.stack[^1];
                set =>
                    //double top = value;
                    //this.stack.Add(value);
                    this.stack[^1] = value;
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

            public void AddConvertedCharValue(char charValue, out double newcharValue)
            {
                newcharValue = (double)charValue;
                this.stack.Add(charValue);
            }

            public void AddStringValue(ref string strValue)
            {
                this.stack.Add(Convert.ToDouble(strValue));
            }

            public void AddTopValue(double value)
            {
                this.stack.Add(value);
            }

            public void ChangeTopValue(ref double newValue)
            {
                this.stack[^1] = newValue;
            }

            public List<double> CreateStack(int stackSize)
            {
                for (int i = 0; i < stackSize; i++)
                {
                    Random random = new Random();
                    this.stack.Add(random.Next(-5, 5));
                }
                return this.stack;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || !GetType().Equals(obj.GetType()))
                {
                    return false;
                }
                else
                {
                    Stck s = (Stck)obj;
                    return this.stack == s.stack;
                }
            }

            public override int GetHashCode()
            {
                return Convert.ToInt32(this.stack[0]) << 2 ^ 3 * objectCounter;
            }

            public List<double> RemoveFromStack()
            {
                this.stack.RemoveAt(this.stack.Count - 1);
                return this.stack;
            }

            public void ShowStack()
            {
                this.stack.Reverse();
                foreach (double f in this.stack)
                {
                    Console.Write("\n" + f);
                }
            }

            public override string ToString()
            {
                double top = this.stack[this.stack.Count - 1];
                return String.Format("top of stack:{0} ", top);
            }
        }
    }
}