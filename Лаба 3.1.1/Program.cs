using System;
using System.Linq;

namespace лаба_3._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите количество элементов массива");
            int count = int.Parse(Console.ReadLine());
            int[] mass = new int[count];
            int ia = 0, ib = 0;
            int proiz = 1;
            for (int i = 0; i < mass.Length; i++)
            {
                Console.WriteLine($"введите значение элемента под индексом {i}");
                mass[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("вывод в порядке убывания");
            
            var sum = mass
                .Where(m => m > 0)
                .Sum();
            int max = mass
                .Select(s => Math.Abs(s))
                .Max();
            int min = mass
                .Select(s => Math.Abs(s))
                .Min();

            for (var index = 0; index < mass.Length; index++)
            {
                var currentSum = mass[0];

                if (currentSum == max)
                {
                    ia = index;
                }
                else if(currentSum == min)
                {
                    ib = index;
                }
            }

            var massOrderByDescending = mass
                .OrderByDescending(x => x)
                .ToList();

            foreach(var m in massOrderByDescending)
            {
                Console.WriteLine(m);
            }
            // -1 2 5 10
            var isChecked = false;
            var total = 0;

            for(var index = 0; index < mass.Length; index++)
            {
                var isTargetIndex = index == ia || index == ib;

                if (isTargetIndex)
                {
                   if(!isChecked)
                    {
                        isChecked = true;
                    }
                   else
                    {
                        isChecked = false;
                    }
                }

                if(isChecked && !isTargetIndex)
                {
                    var targetSum = mass[index];

                    if(total == 0)
                    {
                        total = targetSum;
                    }
                    else
                    {
                        total = total * targetSum;
                    }
                }
            }
            Console.WriteLine("cумма " + sum);
            Console.WriteLine("произведение между элементами макс и мин " + total);
            
            Console.ReadLine();

        }
    }
}

