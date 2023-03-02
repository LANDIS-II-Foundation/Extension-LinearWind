using System;
using System.Collections.Generic;
using System.Text;
using Landis.Utilities;

namespace Landis.Extension.LinearWind
{
    /// <summary>
    /// Definition of a wind severity.
    /// </summary>
    public interface ISeverityTable
    {
        float Group1Low { get; set; }
        float Group1High { get; set; }
        float Group2Low { get; set; }
        float Group2High { get; set; }
        float Group3Low { get; set; }
        float Group3High { get; set; }

        //---------------------------------------------------------------------

        /// <summary>
        /// The probability of cohort mortality due to wind.
        /// </summary>
        float MortalityThreshold
        {
            get; set;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// The severity's number (between 1 and 5).
        /// </summary>
        byte Index
        {
            get; set;
        }
    }


    public class SeverityTable
     : ISeverityTable
    {
        private byte index;
        private float group1Low;
        private float group1High;
        private float group2Low;
        private float group2High;
        private float group3Low;
        private float group3High;
        private float mortalityThreshold;

        //---------------------------------------------------------------------

        /// <summary>
        /// The severity's number (between 1 and 5).
        /// </summary>
        public byte Index
        {
            get
            {
                return index;
            }
            set
            {
                if (value > 5)
                    throw new InputValueException(value.ToString(), "Value must be between 1 and 5.");
                index = value;
            }
        }
        /// <summary>
        /// The probability of cohort mortality due to wind.
        /// </summary>
        public float MortalityThreshold
        {
            get
            {
                return mortalityThreshold;
            }
            set
            {
                if (value < 0.0 || value > 1.0)
                    throw new InputValueException(value.ToString(), "Value must be between 0.0 and 1.0");
                mortalityThreshold = value;
            }
        }
        public float Group1Low
        {
            get
            {
                return group1Low;
            }
            set
            {
                group1Low = value;
            }
        }
        public float Group1High
        {
            get
            {
                return group1High;
            }
            set
            {
                group1High = value;
            }
        }
        public float Group2Low
        {
            get
            {
                return group2Low;
            }
            set
            {
                group2Low = value;
            }
        }
        public float Group2High
        {
            get
            {
                return group2High;
            }
            set
            {
                group2High = value;
            }
        }
        public float Group3Low
        {
            get
            {
                return group3Low;
            }
            set
            {
                group3Low = value;
            }
        }
        public float Group3High
        {
            get
            {
                return group3High;
            }
            set
            {
                group3High = value;
            }
        }
    }
}

