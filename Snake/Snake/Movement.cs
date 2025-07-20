using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Movement
    {

        public static int Width { get; set; }
        public static int Height { get; set; }
        public static string direction;
        public Movement()
        {
            Width = 16;
            Height = 16;
            direction = "left";
        }
    }
}
