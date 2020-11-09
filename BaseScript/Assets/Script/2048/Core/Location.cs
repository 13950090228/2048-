using System;
using System.Collections.Generic;


namespace Console2048
{
    struct Location
    {

        public int rIndex { get; set; }
        public int cIndex { get; set; }

        public Location(int rIndex,int cIndex):this()
        {
            this.rIndex = rIndex;
            this.cIndex = cIndex;
        }
    }
}
