//  Contributors:  Eric Gustafson, Robert M. Scheller, James B. Domingo

using Landis.Utilities;

namespace Landis.Extension.LinearWind
{
    /// <summary>
    /// Extra Ecoregion Paramaters
    /// </summary>
    public interface IEcoParameters
    {
        double EcoModifier{get;set;}
    }
}


namespace Landis.Extension.LinearWind
{
    public class EcoParameters
        : IEcoParameters
    {
        private double ecoModifier;
        //---------------------------------------------------------------------
        /// <summary>
        /// </summary>
        public double EcoModifier{
            get{
                return ecoModifier;
            }
            set {
                ecoModifier = value;
            }
        }
        //---------------------------------------------------------------------
        public EcoParameters()
        {
        }
        //---------------------------------------------------------------------
    }
}
