
using System;

namespace AssemblyCSharp
{
    public class BaseMap
    {
        float x;
        float y;
        BaseMapView mapView;
       
        public BaseMap()
        {
            x = Constants.MAP_SIZE_X;
            y = Constants.MAP_SIZE_Y;
          ///  mapView = new BaseMapView(x, y);
        }

        public BaseMap(float x, float y)
        {
            this.x = x;
            this.y = y;
            //mapView = new BaseMapView(this.x, this.y);
        }

    }
}

