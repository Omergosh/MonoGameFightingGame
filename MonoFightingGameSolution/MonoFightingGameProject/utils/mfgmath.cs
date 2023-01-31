using System;
using System.Collections.Generic;
using System.Text;

namespace MonoFightingGameProject.utils
{
    public struct IntVector2D
    {
        public int x;
        public int y;

        public IntVector2D(int defaultValue = 0)
        {
            x = defaultValue;
            y = defaultValue;
        }

        public IntVector2D Add(IntVector2D other)
        {
            x += other.x;
            y += other.y;
            return this;
        }
    }

    //class mfgmath
    //{
    //}
}
