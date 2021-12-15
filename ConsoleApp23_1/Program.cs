using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp3_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое положительное число от 1 до 20 для нахождения факториала");
            int num = 0;
            try
            {
                num = Math.Abs(Convert.ToInt32(Console.ReadLine()));
            }
            catch
            {
                Console.WriteLine("Не число");
            }
            if (num>20 || num == 0)
            {
                Console.WriteLine("Введите число от 1 до 20 \n");               
                Main(args);
                return;
            }

            Task task1 = Task.Run(() => Factorial(num));

            //task1.Wait();
            var stop = false;
            while (!stop)
            {
                Console.WriteLine(task1.Status);
                Thread.Sleep(50);
                if (task1.Status != TaskStatus.Running)
                {
                    stop = true;
                }
            }

            task1.Wait();
            Console.WriteLine("Обнаружено завершение задачи \n");           
            Console.ReadKey();
            Main(args);
            return;
        }

        static void Factorial(int objnum)
        {
            Console.WriteLine("Начало потока 1");
            Thread.Sleep(100);
            int num = objnum;
            long factorial = 1;
            for (int i = 1; i <= num; i++)
            {
                factorial *= i;
                Console.WriteLine(new String(' ', 20) + factorial);
                Thread.Sleep(50);
            }
            Console.WriteLine($"Факториал числа {objnum}: {factorial}");
            Console.WriteLine("Конец потока 1");           
        }
    }
}



