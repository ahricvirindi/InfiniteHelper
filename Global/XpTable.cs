using System;
using System.Collections.Generic;
using System.Text;

namespace InfiniteHelper.Global
{
    public static class XpTable
    {
        public static long RETAIL_MAX_XP = 191226310247;

        public static long CalcPostRetailNextLevelXp(int currentLevel)
        {
            if (currentLevel < 275)
            {
                return -1;
            }

            double totalXpNeeded = RETAIL_MAX_XP;
            for(var x = 275; x <= currentLevel;x++)
            {
                totalXpNeeded += 3414755540.0 * (1.1 + ((x - 275) * 0.75));
            }

            return (long)totalXpNeeded;
        }

        public static long CalcPostRetailXpToNextLevel(int currentLevel, long totalXp)
        {
            var xpNeeded = CalcPostRetailNextLevelXp(currentLevel);

            xpNeeded = xpNeeded - totalXp;

            return xpNeeded;
        }
    }
}
