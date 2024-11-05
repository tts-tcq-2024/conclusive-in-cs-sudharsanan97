public class AlertManager
{
    public enum AlertTarget { 
        TO_CONTROLLER, 
        TO_EMAIL }

    public static void checkAndAlert(AlertTarget alertTarget, BreachDetector.CoolingType coolingType, double temperatureInC)
    {
        BreachDetector.BreachType breachType = BreachDetector.classifyTemperatureBreach(coolingType, temperatureInC);
        if (alertTarget == AlertTarget.TO_CONTROLLER)
            sendToController(breachType);
        else
            sendToEmail(breachType);
    }

    private static void sendToController(BreachDetector.BreachType breachType)
    {
        Console.WriteLine("0xfeed : %s%n", breachType);
    }

    private static void sendToEmail(BreachDetector.BreachType breachType)
    {
        String recipient = "GurudathGM.com";
        if (breachType != BreachDetector.BreachType.NORMAL)
            Console.WriteLine("To: %s%nHi, the temperature is %s%n", recipient,
                breachType == BreachDetector.BreachType.TOO_LOW ? "too low" : "too high");
    }
}
