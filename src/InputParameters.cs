//  Contributors:  Eric Gustafson, Robert M. Scheller, James B. Domingo

using Landis.Utilities;
using System.Collections.Generic;
using System.Diagnostics;
using Landis.Core;

namespace Landis.Extension.LinearWind
{
	/// <summary>
	/// Parameters for the plug-in.
	/// </summary>
	public class InputParameters
		: IInputParameters
	{
		private int timestep;

        private double numEventsMean;
        private double numEventsStDev;

        private double tornadoLengthLambda;
        private double tornadoLengthAlpha;
        private double tornadoWidth;
        private List<double> tornadoWindIntPct;
        private double tornadoProp;

        private double derechoLengthLambda;
        private double derechoLengthAlpha;
        private double derechoWidth;
        private List<double> derechoWindIntPct;

        private double propIntensityVar;        
        private List<double> windDirPct;
        private IEcoParameters[] ecoParameters;
        //private IEventParameters[] eventParameters;
        private float maxDistanceToEdge;
        private float maxAgeEdge;
        private float maxEdgeEffect;
        //private List<ISeverity> severities;
        private Dictionary<byte,ISeverity> severityDictionary;
        private Library.Parameters.Species.AuxParm<byte> windSensitivity;

        private string mapNamesTemplate;
        private string intensityMapNamesTemplate;
        private string edgeMapNamesTemplate;
        private string logFileName;

		//---------------------------------------------------------------------
		/// <summary>
		/// Timestep (years)
		/// </summary>
		public int Timestep
		{
			get {
				return timestep;
			}
            set {
                if (value < 0)
                    throw new InputValueException(value.ToString(),
                                                      "Value must be = or > 0.");
                timestep = value;
            }
		}
        //---------------------------------------------------------------------
        /// <summary>
        /// Mean number of events /40,000 km2/year
        /// </summary>
        public double NumEventsMean
        {
            get
            {
                return numEventsMean;
            }
            set
            {
                if (value < 0)
                    throw new InputValueException(value.ToString(),
                                                  "Value must be >= 0.");
                numEventsMean = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// StDev number of events /40,000 km2/year
        /// </summary>
        public double NumEventsStDev
        {
            get
            {
                return numEventsStDev;
            }
            set
            {
                numEventsStDev = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Lambda Length (km) - Tornadoes
        /// </summary>
        public double TornadoLengthLambda
        {
            get
            {
                return tornadoLengthLambda;
            }
            set
            {
                if (value < 0)
                    throw new InputValueException(value.ToString(),
                                                  "Value must be >= 0.");
                tornadoLengthLambda = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Alpha Length (km) - Tornadoes
        /// </summary>
        public double TornadoLengthAlpha
        {
            get
            {
                return tornadoLengthAlpha;
            }
            set
            {
                tornadoLengthAlpha = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Width (km) - Tornadoes
        /// </summary>
        public double TornadoWidth
        {
            get
            {
                return tornadoWidth;
            }
            set
            {
                if (value < 0)
                    throw new InputValueException(value.ToString(),
                                                  "Value must be >= 0.");
                tornadoWidth = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Prop of events with small width - Tornadoes
        /// </summary>
        public double TornadoProp
        {
            get
            {
                return tornadoProp;
            }
            set
            {
                if (value > 1.0)
                    throw new InputValueException(value.ToString(),
                                                  "Value must be <= 1.");
                tornadoProp = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Lambda Length (km) - Derechos
        /// </summary>
        public double DerechoLengthLambda
        {
            get
            {
                return derechoLengthLambda;
            }
            set
            {
                if (value < 0)
                    throw new InputValueException(value.ToString(),
                                                  "Value must be >= 0.");
                derechoLengthLambda = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Alpha Length (km) - Derechos
        /// </summary>
        public double DerechoLengthAlpha
        {
            get
            {
                return derechoLengthAlpha;
            }
            set
            {
                derechoLengthAlpha = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Large width (km) - Derechos
        /// </summary>
        public double DerechoWidth
        {
            get
            {
                return derechoWidth;
            }
            set
            {
                if (value < 0)
                    throw new InputValueException(value.ToString(),
                                                  "Value must be >= 0.");
                derechoWidth = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Proportion of event with reduced intensity
        /// </summary>
        public double PropIntensityVar
        {
            get
            {
                return propIntensityVar;
            }
            set
            {
                if (value < 0)
                    throw new InputValueException(value.ToString(),
                                                  "Value must be >= 0.");
                if (value > 1)
                    throw new InputValueException(value.ToString(),
                                                  "Value must be <= 1.");
                propIntensityVar = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Wind direction Pct
        /// </summary>
        public List<double> WindDirPct
        {
            get
            {
                return windDirPct;
            }
            set
            {
                windDirPct = value;
            }

        }
		//---------------------------------------------------------------------
        /// <summary>
        /// Wind Intensity Pct - Tornado
        /// </summary>
        public List<double> TornadoWindIntPct
        {
            get
            {
                return tornadoWindIntPct;
            }
            set
            {
                tornadoWindIntPct = value;
            }

        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Wind Intensity Pct - Derecho
        /// </summary>
        public List<double> DerechoWindIntPct
        {
            get
            {
                return derechoWindIntPct;
            }
            set
            {
                derechoWindIntPct = value;
            }

        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Ecoregion modifiers
        /// </summary>
        /// 		/// <remarks>
        /// Use Ecoregion.Index property to index this array.
        /// </remarks>
        public IEcoParameters[] EcoParameters
        {
            get
            {
                return ecoParameters;
            }
            set
            {
                ecoParameters = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Maximum distance to consider edge effect
        /// </summary>
        public float MaxDistanceToEdge
        {
            get
            {
                return maxDistanceToEdge;
            }
            set
            {
                if (value <= 0)
                    throw new InputValueException(value.ToString(),
                                                  "Value must be > 0.");
                maxDistanceToEdge = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Maximum age to consider edge effect
        /// </summary>
        public float MaxAgeEdge
        {
            get
            {
                return maxAgeEdge;
            }
            set
            {
                if (value <= 0)
                    throw new InputValueException(value.ToString(),
                                                  "Value must be > 0.");
                maxAgeEdge = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Maximum edge effect
        /// </summary>
        public float MaxEdgeEffect
        {
            get
            {
                return maxEdgeEffect;
            }
            set
            {
                if (value <= 0)
                    throw new InputValueException(value.ToString(),
                                                  "Value must be > 0.");
                maxEdgeEffect = value;
            }
        }
        //---------------------------------------------------------------------
       /* /// <summary>
        /// Definitions of wind severities.
        /// </summary>
        public List<ISeverity> WindSeverities
		{
			get {
				return severities;
			}
		}*/
        //---------------------------------------------------------------------
        /// <summary>
        /// Definitions of wind severities.
        /// </summary>
        public Dictionary<byte, ISeverity> SeverityDictionary
        {
            get
            {
                return severityDictionary;
            }
        }
        //---------------------------------------------------------------------
        public Library.Parameters.Species.AuxParm<byte> WindSensitivity
        {
            get
            {
                return windSensitivity;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Template for the filenames for severity output maps.
        /// </summary>
        public string MapNamesTemplate
		{
			get {
				return mapNamesTemplate;
			}
            set {
                MapNames.CheckTemplateVars(value);
                mapNamesTemplate = value;
            }
		}
        //---------------------------------------------------------------------
        /// <summary>
        /// Template for the filenames for intensity output maps.
        /// </summary>
        public string IntensityMapNamesTemplate
        {
            get
            {
                return intensityMapNamesTemplate;
            }
            set
            {
                MapNames.CheckTemplateVars(value);
                intensityMapNamesTemplate = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Template for the filenames for edge modifer output maps.
        /// </summary>
        public string EdgeMapNamesTemplate
        {
            get
            {
                return edgeMapNamesTemplate;
            }
            set
            {
                MapNames.CheckTemplateVars(value);
                edgeMapNamesTemplate = value;
            }
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Name of log file.
        /// </summary>
        public string LogFileName
		{
			get {
				return logFileName;
			}
            set {
                if (value == null)
                    throw new InputValueException(value.ToString(), "Value must be a file path.");
                logFileName = value;
            }
		}
        //---------------------------------------------------------------------
       
        public void SetWMT(byte index, double newValue)
        {
            severityDictionary[index].MortalityThreshold = (float)newValue;
        }
        //---------------------------------------------------------------------
        public void SetWindSensitivity(ISpecies species,
                     byte newValue)
        {
            Debug.Assert(species != null);
            windSensitivity[species] = VerifyRange((int)newValue, 1, 5);
        }
        //---------------------------------------------------------------------
        public InputParameters(int ecoregionCount)
        {
            //severities = new List<ISeverity>();
            severityDictionary = new Dictionary<byte, ISeverity>();
            windDirPct = new List<double>(4);
            tornadoWindIntPct = new List<double>(5);
            derechoWindIntPct = new List<double>(5);
            windSensitivity = new Landis.Library.Parameters.Species.AuxParm<byte>(PlugIn.ModelCore.Species);
            EcoParameters = new IEcoParameters[ecoregionCount];
            for (int i = 0; i < ecoregionCount; i++)
                EcoParameters[i] = new EcoParameters();
        }
        //---------------------------------------------------------------------
        public static byte VerifyRange(int newValue, int minValue, int maxValue)
        {
            if (newValue < minValue || newValue > maxValue)
                throw new InputValueException(newValue.ToString(),
                                              "{0} is not between {1:0.0} and {2:0.0}",
                                              newValue.ToString(), minValue, maxValue);
            return (byte)newValue;
        }
    }
}
