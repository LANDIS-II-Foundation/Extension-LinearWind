//  Authors:  Austen Ruzicka

using Landis.SpatialModeling;

namespace Landis.Extension.LinearWind
{
    public class FloatPixel : Pixel
    {
        public Band<float> MapCode = "The numeric code for each raster cell";

        public FloatPixel()
        {
            SetBands(MapCode);
        }
    }
}
