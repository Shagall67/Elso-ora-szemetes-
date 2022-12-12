using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public class Cell
    {
        public string value { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public bool visited { get; set; }
        public int decay { get; set; }

        public void decaySnake()
        {
            decay -= 1;
            if (decay == 0)
            {
                visited = false;
                value = " ";
            }
        }

        public void Clear()
        {
            value = " ";
        }
    }
}
