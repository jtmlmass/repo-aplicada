using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Introduccion_C_Sharp
{
    class Program
    {

        static void PrintHelloWord()
        {
            Console.WriteLine("\n -- Print Hello World");

            // Imprimir en consola con un \n al final
            Console.WriteLine("Hello World!");
        }

        static void Suma()
        {
            Console.WriteLine("\n -- Suma de dos valores");

            // Definición de variables locales
            int valor1, valor2;

            Console.WriteLine("Digite el primer valor: ");
            // Captura de valor ingresado a consola convertido a Int32
            valor1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite el segundo valor: ");
            valor2 = Convert.ToInt32(Console.ReadLine());

            valor1 += valor2;

            // Concatenación de variable con String de impreción
            Console.WriteLine("Resultado: " + valor1);
        }

        static void SumaConListas()
        {
            Console.WriteLine("\n -- Suma con Listas de valores continuos");

            int valor;
            // Definición de una Lista vacia
            List<int> valores = new List<int>();
            Console.WriteLine("Digite los valores (0 para salir): ");

            // While para agregar un valor mientras diferente de != 0. 
            while ((valor = Convert.ToInt32(Console.ReadLine())) != 0)
            {
                //Agrega a la lista
                valores.Add(valor);
                Console.WriteLine("Capturado. Digite otro valor!");
            }

            Console.WriteLine("Resultado: " + valores.Sum());
            Console.WriteLine("Lista: " + String.Join(" ", valores));
        }

        static void Matrizes()
        {
            Console.WriteLine("\n -- Matrices");

            int tamanoMatriz = 2;
            // Definición de Matriz
            int[,] matriz = new int[tamanoMatriz, tamanoMatriz];
            Console.WriteLine("\nGenerando una matriz " + tamanoMatriz.ToString() + "x" + tamanoMatriz.ToString() + "\n");
            
            // For para navegar matriz
            for(int i = 0; i<tamanoMatriz; i++)
            {
                for(int j = 0; j<tamanoMatriz; j++)
                {
                    matriz[i, j] = (i + j) * (i + 1) * (j * 4) - (i * 3) + (i * j);
                }
            }

            // Por cada valor en la matriz
            foreach (int val in matriz)
                Console.WriteLine("{0}", val);

            // Para pausar la consola se utiliza aqui
            Console.ReadKey();
        }

        static void IfElse()
        {
            Console.WriteLine("\n -- If / Else");

            int num1, num2;

            // Console.Write para imprimir sin linea
            Console.Write("Digite el primer valor: ");
            num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite el segundo valor: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            if(num1 > num2)
            {
                Console.WriteLine("{0} es mayor que {1}", num1, num2);
            } 
            else if(num1 < num2) 
            {
                Console.WriteLine("{0} es menor que {1}", num1, num2);
            }
            else
            {
                Console.WriteLine("{0} es igual que {1}", num1, num2);
            }
        }

        static void SwitchCase()
        {
            Console.WriteLine("\n -- Switch / Case");

            // ¿Por qué una variable con raya abajo?
            int _resp;
            Console.Write("¿En cuál continente nació usted?\n\n1) america\n2) Europa\n3) Africa\n4) Asia\n5) Oceanía\n\nEspecifique: ");
            _resp = Convert.ToInt32(Console.ReadLine());


            // Para elegir acciones a valor especifico de la variable _resp (Respuesta)
            switch (_resp)
            {
                case 1:
                    Console.WriteLine("\nUsted es americano.");
                    break;
                case 2:
                    Console.WriteLine("\nUsted es europeo.");
                    break;
                case 3:
                    Console.WriteLine("\nUsted es africano.");
                    break;
                case 4:
                    Console.WriteLine("\nUsted es asiático.");
                    break;
                case 5:
                    Console.WriteLine("\nUsted es oceánico.");
                    break;
                default:
                    Console.WriteLine("\nHa especificado una entrada incorrecta.");
                    break;
            }

            Console.ReadKey();
        }

        static void CiclosBucles()
        {
            Console.WriteLine("\n -- Ciclos y Bucles");

            int _filas;

            Console.Write("Especifique la cant. de filas del triángulo: ");

            _filas = Convert.ToInt32(Console.ReadLine());

            // ¿Por qué las variables con --?
            while(_filas-- >= 0)
            {
                int _tmp = _filas;

                while (_tmp-- >= 0)
                    Console.Write("*");

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        static void ArchivosDeTexto()
        {
            Console.WriteLine("\n -- Archivos de Texto");

            // Crear un archivo llamado
            using (Stream s = new FileStream("prueba.txt", FileMode.Create))
            {
                Console.WriteLine(s.CanRead);  // True
                Console.WriteLine(s.CanWrite); // True
                Console.WriteLine(s.CanSeek);  // True

                s.WriteByte(101);
                s.WriteByte(102);
                byte[] bloque = { 1, 2, 3, 4, 5 };
                s.Write(bloque, 0, bloque.Length); // Graba 5 bytes

                // Código para desplazarnos y leer
                Console.WriteLine(s.Length); // 7
                Console.WriteLine(s.Position); // 7
                s.Position = 0; // Nos movemos al inicio.

                Console.WriteLine(s.ReadByte()); // 101
                Console.WriteLine(s.ReadByte()); // 102

                // Volvemos a leer desde el Stream al arreglo:
                Console.WriteLine(s.Read(bloque, 0, bloque.Length));

                /* Si la línea anterior retornó 5, estareamos al final del archivo,
                   por lo que volver a leer nos retorna 0*/
                Console.WriteLine(s.Read(bloque, 0, bloque.Length));
            }

            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            PrintHelloWord();
            Suma();
            SumaConListas();
            Matrizes();
            IfElse();
            SwitchCase();
            CiclosBucles();
            ArchivosDeTexto();
        }
    }
}
