using Microsoft.AppCenter.Analytics;
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
    }
}
