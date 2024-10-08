//  Contributors:  Eric Gustafson, Robert M. Scheller, James B. Domingo

using Landis.Core;
using Landis.SpatialModeling;
using Landis.Library.UniversalCohorts;
using System;

namespace Landis.Extension.LinearWind
{
    public static class SiteVars
    {
        private static ISiteVar<Event> eventVar;
        private static ISiteVar<int> timeOfLastEvent;
        private static ISiteVar<byte> severity;
        private static ISiteVar<bool> disturbed;
        private static ISiteVar<SiteCohorts> cohorts;
        private static ISiteVar<double> intensity;

        //---------------------------------------------------------------------

        public static void Initialize()
        {
            eventVar        = PlugIn.ModelCore.Landscape.NewSiteVar<Event>(InactiveSiteMode.DistinctValues);
            cohorts = PlugIn.ModelCore.GetSiteVar<SiteCohorts>("Succession.UniversalCohorts");

            disturbed = PlugIn.ModelCore.Landscape.NewSiteVar<bool>();
            timeOfLastEvent = PlugIn.ModelCore.GetSiteVar<int>("Wind.TimeOfLastEvent");  // If other wind disturbance extension is active, use the registered site var from it
            severity = PlugIn.ModelCore.GetSiteVar<byte>("Wind.Severity");  // If other wind disturbance extension is active, use the registered site var from it
            if (timeOfLastEvent == null)
            {
                timeOfLastEvent = PlugIn.ModelCore.Landscape.NewSiteVar<int>();
                PlugIn.ModelCore.RegisterSiteVar(SiteVars.TimeOfLastEvent, "Wind.TimeOfLastEvent");
            }
            if (severity == null)
            {
                severity = PlugIn.ModelCore.Landscape.NewSiteVar<byte>();
                PlugIn.ModelCore.RegisterSiteVar(SiteVars.Severity, "Wind.Severity");
            }

            intensity = PlugIn.ModelCore.Landscape.NewSiteVar<double>();
            
            
        }
        //---------------------------------------------------------------------
        public static void ReInitialize()
        {
            timeOfLastEvent = PlugIn.ModelCore.GetSiteVar<int>("Wind.TimeOfLastEvent");  // If other wind disturbance extension is active, use the registered site var from it
            severity = PlugIn.ModelCore.GetSiteVar<byte>("Wind.Severity");  // If other wind disturbance extension is active, use the registered site var from it
            if(timeOfLastEvent == null)
            {
                timeOfLastEvent = PlugIn.ModelCore.Landscape.NewSiteVar<int>();
            }
            if (severity == null)
            {
                severity = PlugIn.ModelCore.Landscape.NewSiteVar<byte>();
            }

        }
        //---------------------------------------------------------------------
        public static ISiteVar<SiteCohorts> Cohorts
        {
            get
            {
                return cohorts;
            }
        }
        //---------------------------------------------------------------------

        public static ISiteVar<Event> Event
        {
            get {
                return eventVar;
            }
        }

        //---------------------------------------------------------------------

        public static ISiteVar<int> TimeOfLastEvent
        {
            get {
                return timeOfLastEvent;
            }
        }

        //---------------------------------------------------------------------

        public static ISiteVar<byte> Severity
        {
            get {
                return severity;
            }
        }
        //---------------------------------------------------------------------

        public static ISiteVar<bool> Disturbed
        {
            get {
                return disturbed;
            }
        }
        //---------------------------------------------------------------------

        public static ISiteVar<double> Intensity
        {
            get
            {
                return intensity;
            }
        } 
    }
}
