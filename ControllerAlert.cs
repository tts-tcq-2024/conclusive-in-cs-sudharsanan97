using System;

public class ControllerAlert : IAlert
{
    public void SendAlert(BreachType breachType)
    {
       const ushort header = 0xfeed;
       Console.WriteLine($"0x{header:x} : {breachType}");
    }
}
