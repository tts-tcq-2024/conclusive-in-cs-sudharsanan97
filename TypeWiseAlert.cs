using System;

public static class TypewiseAlert
{
    public static BreachType InferBreach(double value, double lowerLimit, double upperLimit)
    {
        if (value < lowerLimit)
        {
            return BreachType.TOO_LOW;
        }
        if (value > upperLimit)
        {
            return BreachType.TOO_HIGH;
        }
        return BreachType.NORMAL;
    }

    public static BreachType ClassifyTemperatureBreach(ICoolingStrategy coolingStrategy, double temperatureInC)
    {
        return coolingStrategy.ClassifyTemperature(temperatureInC);
    }
    public static void CheckAndAlert(AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC)
    {
        ICoolingStrategy strategy = AlertFactory.CreateCoolingStrategy(batteryChar.coolingType);
        BreachType breachType = ClassifyTemperatureBreach(strategy, temperatureInC);

        IAlert alert = AlertFactory.CreateAlert(alertTarget);
        alert.SendAlert(breachType);
    }
}
