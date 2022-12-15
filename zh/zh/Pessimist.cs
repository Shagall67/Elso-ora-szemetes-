using System;
using System.Collections.Generic;
using System.Text;

namespace Tomi_zh
{
    class Pessimist : Engszi
    {
        public Pessimist()
        {
            Random r = new Random();
            this.Happy = r.Next(0, 21);
        }
        public void Meet (Engszi engszi)
        {
            if (engszi is Optimist)
            {
                this.Happy /= 2;
            }
        }
    }
}
