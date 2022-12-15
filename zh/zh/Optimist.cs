using System;
using System.Collections.Generic;
using System.Text;

namespace Tomi_zh
{
    class Optimist : Engszi
    {
        public Optimist()
        {
            Random r = new Random();
            this.Happy = r.Next(60, 101);
        }
    }
}
