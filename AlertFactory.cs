using System;

public static class AlertFactory
{
    public static IAlert CreateAlert(AlertTarget alertTarget)
    {
        return alertTarget switch
        {
            AlertTarget.TO_CONTROLLER => new ControllerAlert(),
            AlertTarget.TO_EMAIL => new EmailAlert(),
            _ => throw new ArgumentOutOfRangeException(nameof(alertTarget), alertTarget, null)
        };
    }
    public static ICoolingStrategy CreateCoolingStrategy(CoolingType coolingType)
    {
        return coolingType switch
        {
            CoolingType.PASSIVE_COOLING => new PassiveCooling(),
            CoolingType.HI_ACTIVE_COOLING => new HiActiveCooling(),
            CoolingType.MED_ACTIVE_COOLING => new MedActiveCooling(),
            _ => throw new ArgumentOutOfRangeException(nameof(coolingType), coolingType, null)
        };
    }
}
