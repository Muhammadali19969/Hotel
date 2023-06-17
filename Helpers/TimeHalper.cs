
using Hotel.Constants;
using System;

namespace Hotel.Helpers;

internal class TimeHalper
{
    public static DateTime GetDateTime()
    {
        var dtTime = DateTime.UtcNow;
        dtTime.AddHours(TimeConstants.UTC);
        return dtTime;
    }
}
