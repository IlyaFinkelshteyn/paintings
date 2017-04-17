using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Painting.Website.Models
{
    public class Image
    {
        public class Image2
        {
            public Level[] levels { get; set; }
        }

        public class Level
        {
            public string name { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public Tile[] tiles { get; set; }
        }

        public class Tile
        {
            public int x { get; set; }
            public int y { get; set; }
            public string url { get; set; }
        }

    }
}
