using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProducerandConsumer
{
    public class Buffer
    {
         Semaphore semvacio;
         Semaphore semnolleno;
         int[] buf;

         int producer, consumer, size, numProcesos;

        public Buffer(int tam)
        {
            buf = new int[tam];
            semvacio = new Semaphore(0, tam);
            semnolleno = new Semaphore(tam, tam);
            consumer = 0;
            producer = 0;
            size = tam;
            numProcesos = 0;
        }
        public void Producer(int proceso)
        {
            semnolleno.WaitOne();
                buf[producer++] = proceso;
                if (producer == size)
                {
                    producer = 0;
                }
                numProcesos++;
            semvacio.Release();
        }
        public int Consumer()
        {
            int proceso;
           semvacio.WaitOne();
                proceso = buf[consumer++];
                if (consumer == size)
                {
                    consumer = 0;
                }
                numProcesos--;
            semnolleno.Release();
            return proceso;
        }

    }
}
