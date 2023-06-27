using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ahorkadoPremium
{
     class Program
    {
        static void Main(string[] args)
        {
            int opc;
            palabras p = new palabras();
            tPalabras tP = new tPalabras(100);

            do
            {
                System.Console.WriteLine("\n¿Qué quieres hacer?\n 1)Jugar \n 0)Salir");
                opc = int.Parse(System.Console.ReadLine());
                switch (opc)
                {
                    case 1:

                        tP.leerBDNivel();

                        System.Console.WriteLine("\n La palabra misteriosa:");

                        tP.dibujarPalabra(tP.sortearpalabras());

                        break;
                    case 0:


                        System.Console.WriteLine("\n Hasta otra Mari Carmen!!");

                    

                        break;


                    default:
                        Console.WriteLine("Una opción de la lista!!");
                        break;
                }


            } while (opc != 0);


            Console.ReadKey();
        }
    }
}
  
