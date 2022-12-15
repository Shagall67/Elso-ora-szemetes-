using System;
using System.Collections.Generic;
using System.Text;

namespace Tomi_zh
{
    class Ngc
    {
        int Population { get; set; }
        List<Engszi> Residents { get; set; }
        public Ngc(int population)
        {
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
    }
}
