using System;
using System.Collections.Generic;
using System.Text;

namespace Tomi_zh
{
    class Average : Engszi
    {
        public Average()
        {
            Random r = new Random();
            this.Happy = r.Next(0, 101);
        }

        public void Meet (Engszi engszi)
        {
            this.Happy = engszi.Happy;
        }
    }
}
