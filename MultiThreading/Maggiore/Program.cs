using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maggiore
{
    class Program
    {
        static void Main(string[] args)
        {
            //stabilire il maggiore tra 3 numeri
            int x;
            int y;
            int z;
            int k;

            //modalità sequanziale
            x = 20;
            y = 13;
            z = 21;
            k = Max(x, y);
            k = Max(k, z);
            Console.WriteLine($"in numero più grande tra {z}, {y} e {z} è {k}");

            //modalità multithreading
            var leggi_x = Task.Factory.StartNew(() =>
            {
                x = 20;
            });
            var leggi_y = Task.Factory.StartNew(() =>
            {
                y = 13;
            });

            //attesa delle due letture
            Task[] tmpTaskArray = new Task[] { leggi_x, leggi_y };
            Task.WaitAll(tmpTaskArray);

            var max_xy = Task.Factory.StartNew(() =>
            {
                k = Max(x, y);
            });
            var leggi_z = Task.Factory.StartNew(() =>
            {
                z = 21;
            });

            //attesa 
            Task[] tmpTaskArray1 = new Task[] { max_xy, leggi_z };
            Task.WaitAll(tmpTaskArray);

            var max_kz = Task.Factory.StartNew(() =>
            {
                k = Max(k, z);
            });

            Console.WriteLine($"in numero più grande tra {z}, {y} e {z} è {k}");

            Console.ReadLine();
        }

        /// <summary>
        /// restituisce il più grande fra due numeri
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        static int Max(int num1, int num2)
        {
            if (num1 > num2)
                return num1;
            else
                return num2;
        }
    
    }
}
