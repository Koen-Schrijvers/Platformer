using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Terrain
{
    internal enum BlockType
    {
        SOLO = 1,
        UPPER_LEFT,
        UPPER_MIDDLE,
        UPPER_RIGHT,
        CENTER_LEFT, 
        CENTER_MIDDLE, 
        CENTER_RIGHT,
        LOWER_LEFT,
        LOWER_LEFT_GRASS,
        LOWER_MIDDLE,
        LOWER_RIGHT,
        LOWER_RIGHT_GRASS,
        PILLAR_TOP,
        PILLAR_MIDDLE,
        PILLAR_BOTTOM,
        PLATFORM_LEFT,
        PLATFORM_MIDDLE,
        PLATFORM_RIGHT,
        SPIKE_TRAP,
    }
}
