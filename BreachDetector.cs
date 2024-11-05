using System.Collections.Generic;

public class BreachDetector
{
    static Dictionary<CoolingType, int> coolingLimits = new Dictionary<CoolingType, int>
                {
            { CoolingType.PASSIVE_COOLING, 35 },
            { CoolingType.MED_ACTIVE_COOLING, 40 },
            { CoolingType.HI_ACTIVE_COOLING, 45 }
        };

    public enum BreachType 
    { 
        NORMAL, 
        TOO_LOW, 
        TOO_HIGH 
    }
    public enum CoolingType 
    { 
        PASSIVE_COOLING,
        MED_ACTIVE_COOLING,
        HI_ACTIVE_COOLING
    }

    public static BreachType inferBreach(double value, double lowerLimit, double upperLimit)
    {
        if (value < lowerLimit) return BreachType.TOO_LOW;
        if (value > upperLimit) return BreachType.TOO_HIGH;
        return BreachType.NORMAL;
    }

    public static int getUpperLimit(CoolingType coolingType)
    {
        return coolingLimits.TryGetValue(coolingType, out int limit) ? limit : default;
    }

    public static BreachType classifyTemperatureBreach(CoolingType coolingType, double temperatureInC)
    {
        int lowerLimit = 0, upperLimit = 0;
        upperLimit = getUpperLimit(coolingType);
        return inferBreach(temperatureInC, lowerLimit, upperLimit);
    }
}
