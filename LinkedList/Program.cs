using LinkedList.Model;
using System;

namespace LinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Delete(3);

            foreach(var item in list)
            {
                Console.Write($"{item} ");
            }

            list.AppendHead(12);
            Console.WriteLine();

            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            list.InsertAfter(4, 10);

            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

        }
    }
}
