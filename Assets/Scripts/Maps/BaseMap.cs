
using System;

namespace AssemblyCSharp
{
    public class BaseMap
    {
        class MapSize
        {
            float x;
            float y;

            public MapSize(float x, float y)
            {
                X = x;
                Y = y;
            }

            public float X
            {
                get{ return x;}
                set{ x = value;}
            }

            public float Y
            {
                get{ return y;}
                set{ y = value;}
            }                  
        }

        MapSize mapSize;
       
        public BaseMap()
        {
            mapSize = new MapSize(Constants.MAP_SIZE_X, Constants.MAP_SIZE_Y); 
        }

        public BaseMap(float x, float y)
        {
            mapSize = new MapSize(x, y);
        }
    }
}

