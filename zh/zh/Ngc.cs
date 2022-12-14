using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Tomi_zh
{
    class Ngc
    {
        int Population { get; set; }
        List<Engszi> Residents { get; set; }
        public Ngc(int population)
        {
            Residents = new List<Engszi>();
            Random r = new Random();
            this.Population = population;
            for (int i = 0; i < population; i++)
            {
                int k = r.Next(0, 101);
                if (k < 68) // 67 % esellyel áltag
                {
                    Residents.Add(new Average());
                }
                else if (k < 88) // 1/5 eséllyel optimista
                {
                    Residents.Add(new Optimist());
                }
                else // maradek pesszimista
                {
                    Residents.Add(new Pessimist());
                }
            }
        }
        public void Simulate(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                Random r = new Random();
                foreach (var engszi in Residents) // mindegyik engszi mozog 1-et
                {
                    engszi.Position = r.Next(0, 101);
                }
                foreach (var engszi in Residents) // találkozások
                {
                    foreach (var e in Residents)
                    {
                        if (e.Position == engszi.Position)
                        {
                            engszi.Meet(e);
                            e.Meet(engszi);
                        }
                    }
                }
                Console.WriteLine(this.GetAllHappy());
                Thread.Sleep(500);
            }
        }

        public int GetAllHappy()
        {
            int allHappy = 0;
            foreach (var engszi in Residents)
            {
                allHappy += engszi.Happy;
            }
            return allHappy;
        }
    }
}
