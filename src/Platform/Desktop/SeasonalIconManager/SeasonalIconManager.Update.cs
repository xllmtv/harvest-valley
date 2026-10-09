using System;

namespace HarvestValley.Platform.Desktop;

public static partial class SeasonalIconManager
{
    public static void Update()
    {
        int currentMonth = DateTime.Now.Month;
        if (currentMonth == _lastMonth)
        {
            return;
        }

        Refresh();
    }
}
