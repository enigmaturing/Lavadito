using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lavadito
{
    public class AppCenterHelper
    {
        public static void TrackEvent(string eventName, Dictionary<string, string> properties = null)
        {
            Analytics.TrackEvent(eventName, properties);
        }

        public static void TrackError(Exception ex, Dictionary<string, string> properties = null)
        {
            Crashes.TrackError(ex, properties);
        }
    }
}
