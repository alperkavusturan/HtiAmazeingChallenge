using System;
using System.Collections.Generic;
using System.Text;

namespace AmazeingCore.Entity
{
    public class Tile
    {
        public Enums.Tile Type { get; set; }
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public bool isVisited { get; set; } = false;
    }
}
