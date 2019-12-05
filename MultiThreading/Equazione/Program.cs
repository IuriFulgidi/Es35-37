using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equazione
{
    class Program
    {
        static void Main(string[] args)
        {
            //risolvere (2*6)+(1+4)*(5-2)
            Console.WriteLine("risoluzione ( 2 * 6 ) + ( 1 + 4 ) * ( 5 - 2 )");
            //dichiarazione variabili
            int ris_par1 = 0;
            int ris_par2 = 0;
            int ris_par3 = 0;
            int ris_molt = 0;
            int ris_finale;

            //operazioni tra le parentesi
            var parentesi1 = Task.Factory.StartNew(() =>
            {
                //attesa di un secondo per testare che effettivamente funzioni
                Thread.Sleep(1000);
                ris_par1 = 2 * 6;
                Console.WriteLine($"prima parentesi : 2 * 6 = {ris_par1}");
            });
            var parentesi2 = Task.Factory.StartNew(() =>
            {
                ris_par2 = 1 + 4;
                Console.WriteLine($"seconda  parentesi : 1 + 4 = {ris_par2}");
            });
            var parentesi3 = Task.Factory.StartNew(() =>
            {
                ris_par3 = 5 - 2;
                Console.WriteLine($"terza  parentesi : 5 - 2 = {ris_par3}");
            });

            //moltiplicazione
            //attesa delle due parentesi
            Task[] tmpTaskArray = new Task[] { parentesi2, parentesi3 };
            Task.WaitAll(tmpTaskArray);

            //moltiplicazione effettiva
            var moltiplicazione = Task.Factory.StartNew(() =>
            {
                ris_molt = ris_par2 * ris_par3;
                Console.WriteLine($"moltiplicazione: {ris_par2} * { ris_par3} = {ris_molt}");
            });

            //calcolo finale
            //List<Task> taskList = GetTaskList();
            //attesa del completamento di tutte le task
            Task[] taskArray = new Task[] { parentesi1, moltiplicazione };
            Task.WaitAll(taskArray);

            //risultato finale
            var risultato = Task.Factory.StartNew(() =>
            {
                ris_finale = ris_molt + ris_par1;
                Console.WriteLine($"somma: {ris_par1} + {ris_molt} = {ris_finale}");
            });

            Task.WaitAny(risultato);

            Console.ReadLine();
        }
    }
}
