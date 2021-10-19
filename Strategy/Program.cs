using System;
using System.Collections.Generic;

namespace Strategy
{

    public interface ISortStrategy
    {
        void Sort(List<string> list);
    }

    public class QuickSort : ISortStrategy
    {
        public void Sort(List<string> list)
        {
            list.Sort();  // Default is Quicksort
            Console.WriteLine("QuickSorted list ");
        }
    }

    public class ShellSort : ISortStrategy
    {
        public void Sort(List<string> list)
        {
            //list.ShellSort();  not-implemented
            Console.WriteLine("ShellSorted list ");
        }
    }

    public class MergeSort : ISortStrategy
    {
        public void Sort(List<string> list)
        {
            //list.MergeSort(); not-implemented
            Console.WriteLine("MergeSorted list ");
        }
    }

    public class SortedList
    {
        private List<string> list = new List<string>();
        private ISortStrategy sortstrategy;

        public void SetSortStrategy(ISortStrategy sortstrategy)
        {
            this.sortstrategy = sortstrategy;
        }
        public void Add(string name)
        {
            list.Add(name);
        }
        public void Sort()
        {
            sortstrategy.Sort(list);
            
            foreach (string name in list)
            {
                Console.WriteLine(" " + name);
            }
            
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            SortedList list = new SortedList();
            list.Add("Kenan");
            list.Add("Nebi");
            list.Add("Emiraslan");
            list.Add("Kamal");

            list.SetSortStrategy(new QuickSort());
            list.Sort();

            list.SetSortStrategy(new ShellSort());
            list.Sort();

            list.SetSortStrategy(new MergeSort());
            list.Sort();
        }
    }
}
