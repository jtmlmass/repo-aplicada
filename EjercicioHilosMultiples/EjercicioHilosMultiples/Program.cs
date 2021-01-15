using System;
using System.Threading;

namespace EjercicioHilosMultiples
{
    public class Alpha
    {
        // Este método será invocado cuando inicie el hilo.
        public void Beta()
        {
            while (true)
            {
                Console.WriteLine("Alpha.Beta está ejecutando ejecutando en su propio hilo.");
            }
        }
    }

    public class Simple
    {
        public static int Main(string[] args)
        {
            Console.WriteLine("Ejemplo de Thread Start/Stop/Join");

            Alpha oAlpha = new Alpha();

            // Crear el objeto Hilo, pasándole el método Alpha.Beta
            // A través de un delegado ThreadStart. Esta parte no inicia el hilo.
            Thread oThread = new Thread(new ThreadStart(oAlpha.Beta));

            // Iniciar el hilo
            oThread.Start();

            // Esperar a que el estado del hilo sea "Alive"
            while (!oThread.IsAlive) ;

            // Detener el hilo principal por un milisegundo para que oThread haga su trabajo
            Thread.Sleep(1);

            // Enviar la interrupción:
            oThread.Abort();

            // Esperar a que oThread termine. Join también tiene sobrecargas para esperar un
            // intervalo de tiempo.
            oThread.Join();

            Console.WriteLine();
            Console.WriteLine("Alpha.Beta terminó.");

            try
            {
                Console.WriteLine("Intenta reiniciar el hilo Alpha.Beta");
                oThread.Start();
            }
            catch (ThreadStateException)
            {
                Console.Write("ThreadStateException tratando de reiniciar Alpha.Beta. ");
                Console.WriteLine("Fue esperado, debido a que los hilos abortados no pueden ser reiniciados. ");
            }

            return 0;
        }
    }
}
