//  Contributors:  Eric Gustafson, Robert M. Scheller, James B. Domingo

using Landis.Utilities;

namespace Landis.Extension.LinearWind
{

    /// <summary>
    /// Definition of a wind severity.
    /// </summary>
    public interface ISeverity
    {
        /// <summary>
        /// The range of cohort ages (as % of species longevity) that the
        /// severity applies to.
        /// </summary>
        //Range<double> AgeRange
        //{
        //    get;
        //}

        double MinAge {get;set;}
        double MaxAge {get;set;}

        //---------------------------------------------------------------------

        /// <summary>
        /// The probability of cohort mortality due to wind.
        /// </summary>
        float MortalityThreshold
        {
            get;set;
        }

        //---------------------------------------------------------------------

        /// <summary>
        /// The severity's number (between 1 and 254).
        /// </summary>
        byte Number
        {
            get;set;
        }
    }

	/// <summary>
	/// Definition of a wind severity.
	/// </summary>
	public class Severity_Old
		: ISeverity
	{
		private byte number;
		//private Range<double> ageRange;
        private double minAge;
        private double maxAge;
		private float mortalityThreshold;

		//---------------------------------------------------------------------

		/// <summary>
		/// The severity's number (between 1 and 254).
		/// </summary>
		public byte Number
		{
			get {
				return number;
			}
            set {
                if (value == 255)
                    throw new InputValueException(value.ToString(), "Value must be between 1 and 254.");
                number = value;
            }
		}

        //---------------------------------------------------------------------

        /// <summary>
        /// The minimum value of the range of cohort ages (as % of species
        /// longevity) that the severity applies to.
        /// </summary>
        public double MinAge
        {
            get {
                return minAge;
            }

            set {
                ValidateAge(value);
                if (maxAge != 0.0 && value > maxAge)
                    throw new InputValueException(value.ToString(), "Value must be < or = MaxAge");
                minAge = value;
            }
        }
        //---------------------------------------------------------------------

        /// <summary>
        /// The maximum value of the range of cohort ages (as % of species
        /// longevity) that the severity applies to.
        /// </summary>
        public double MaxAge
        {
            get {
                return maxAge;
            }

            set {
                ValidateAge(value);
                if (minAge != 0.0 && value < minAge)
                        throw new InputValueException(value.ToString(), "Value must be = or > MinAge");
                maxAge = value;
            }
        }
		//---------------------------------------------------------------------

		/// <summary>
		/// The range of cohort ages (as % of species longevity) that the
		/// severity applies to.
		/// </summary>
		/*public Range<double> AgeRange
		{
			get {
				return ageRange;
			}
		}*/

        //---------------------------------------------------------------------

        private void ValidateAge(double age)
        {
            if (age < 0.0 || age > 1.0)
                throw new InputValueException(age.ToString(), "Value must be between 0% and 100%");
        }
		//---------------------------------------------------------------------

		/// <summary>
		/// The probability of cohort mortality due to wind.
		/// </summary>
		public float MortalityThreshold
		{
			get {
				return mortalityThreshold;
			}
            set {
                if (value < 0.0 || value > 1.0)
                    throw new InputValueException(value.ToString(), "Value must be between 0.0 and 1.0");
                mortalityThreshold = value;
            }
		}

        //---------------------------------------------------------------------

        public Severity_Old()
        {
        }

		//---------------------------------------------------------------------

	}
}
