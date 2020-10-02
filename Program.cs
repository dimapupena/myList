using MyOwnList;
using System;
using System.Numerics;
using System.Windows;

namespace lab_1__sem_5_
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();

            while (true)
{
                Console.WriteLine("1:  Add element");
                Console.WriteLine("2:  delete element");
                Console.WriteLine("3:  Get Element");
                Console.WriteLine("4:  Clear list");
                Console.WriteLine("5:  Find element");
                Console.WriteLine("6:  Copy List");
                Console.WriteLine("7:  Exam for Enumerator");
                Console.WriteLine("8:  Insert Element");
                Console.WriteLine("9:  See List");
                Console.WriteLine("10: Exit");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        Console.WriteLine("Enter number: ");
                        int addNumber = Convert.ToInt32(Console.ReadLine());
                        list.Add(addNumber);
                        break;

                    case "2":
                        Console.WriteLine("Enter index: ");
                        int removeNumber = Convert.ToInt32(Console.ReadLine());
                        list.RemoveAt(removeNumber);
                        break;

                    case "3":
                        Console.WriteLine("Enter index: ");
                        int getIndex = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(list[getIndex]);
                        break;

                    case "4":
                        list.Clear();
                        break;

                    case "5":
                        Console.WriteLine("Enter number: ");
                        int findElement = Convert.ToInt32(Console.ReadLine());
                        list.Contains(findElement);
                        break;

                    case "6":
                        int[] newList = new int[list.Count];
                        list.CopyTo(newList, list.Count-1);
                        break;

                    case "7":
                        Console.WriteLine(list.GetEnumerator());
                        break;

                    case "8":
                        Console.WriteLine("Enter number: ");
                        int insertNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter index: ");
                        int insertIndex = Convert.ToInt32(Console.ReadLine());
                        list.Insert(insertIndex, insertNumber);
                        break;

                    case "9":
                        Console.WriteLine("//////////////////");
                        foreach (int i in list) {
                            Console.WriteLine(i);
                        }
                        
                        break;

                    case "10":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("oooops, sooory something wrong, try again...\n");
                        break;
                }
            }

        }

    }
}
