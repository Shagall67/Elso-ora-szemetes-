using System;
using System.Collections.Generic;
using System.Text;

namespace Tomi_zh
{
    abstract class Engszi
    {
        public int Position { get; set; }
        public int Happy { get; set; }

        public abstract void Meet(Engszi engszi);
    }
}
