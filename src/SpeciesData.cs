//  Authors:  Robert M. Scheller, James B. Domingo

using Landis.SpatialModeling;
using Landis.Core;
using System.Collections.Generic;
using Landis.Utilities;

namespace Landis.Extension.LinearWind
{
    public class SpeciesData
    {
        public static Library.Parameters.Species.AuxParm<byte> WindSensitivity;

          //---------------------------------------------------------------------
        public static void Initialize(IInputParameters parameters)
        {
            WindSensitivity = parameters.WindSensitivity;
        }
    }
}
