using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProducerandConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffer buf = new Buffer(1);
            Random ran = new Random();
            var p1 = new Thread(() =>
                {

                    while (true)
                    {
                        int p = ran.Next(1, 100);
                        buf.Producer(p);
                        Console.WriteLine("Se ha producido el proceso # " + p + " de P1 \n");
                        Thread.Sleep(1000);
                    }
                });
            var c1 = new Thread(() =>
                {
                    while (true)
                    {
                        int c = buf.Consumer();
                        Console.WriteLine("Se ha consumido el proceso # " + c + " de P1" + " \n");
                        Thread.Sleep(1000);
                    }
                });


            p1.Start();
            c1.Start();
            Console.ReadLine();
        }
    }
}
