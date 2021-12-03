using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    public class Block
    {
        public int width;
        public int height;
        public int crackCount = 0;
        public int x;
        public int y; 
        public int hp;
        public Color colour;
        public SolidBrush brush;

        public static Random rand = new Random();

        public Block(int _x, int _y, int _hp, int _width, int _height, Color _colour)
        {
            x = _x;
            y = _y;
            hp = _hp;
            width = _width;
            height = _height;
            colour = _colour;
            brush = new SolidBrush(colour);
        }
    }
}
