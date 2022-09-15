using System;

namespace Szemetes
{
    class Szamolo
    {
        public static int number = 0;

        public Szamolo() 
        {
            number++;
            Console.WriteLine(number);
        }

        ~Szamolo() 
        {
            number = 0;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            

            while (true) 
            {
                Szamolo sz = new Szamolo();

                if (Szamolo.number == 0){
                    Console.WriteLine("Vegeztem");
                    break;
                }
            }



        }
    }
}
