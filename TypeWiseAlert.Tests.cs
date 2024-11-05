using System;
using Xunit;

public class TypewiseAlertTests
{
    [Fact]
    public void PassiveCooling_TooLowTemperature_ReturnsTooLow()
    {
        var strategy = new PassiveCooling();
        var result = strategy.ClassifyTemperature(-1);
        Assert.Equal(BreachType.TOO_LOW, result);
    }

    [Fact]
    public void HiActiveCooling_NormalTemperature_ReturnsNormal()
    {
        var strategy = new HiActiveCooling();
        var result = strategy.ClassifyTemperature(30);
        Assert.Equal(BreachType.NORMAL, result);
    }

    [Fact]
    public void MedActiveCooling_TooHighTemperature_ReturnsTooHigh()
    {
        var strategy = new MedActiveCooling();
        var result = strategy.ClassifyTemperature(41);
        Assert.Equal(BreachType.TOO_HIGH, result);
    }

    [Fact]
    public void EmailAlert_TooHighTemperature_PrintsEmail()
    {
        var emailAlert = new EmailAlert();
        using (var consoleOutput = new ConsoleOutput())
        {
            emailAlert.SendAlert(BreachType.TOO_HIGH);
            Assert.Contains("Hi, the temperature is too high", consoleOutput.GetOutput());
        }
    }

    [Fact]
    public void ControllerAlert_TooLowTemperature_PrintsControllerMessage()
    {
        var controllerAlert = new ControllerAlert();
        using (var consoleOutput = new ConsoleOutput())
        {
            controllerAlert.SendAlert(BreachType.TOO_LOW);
            Assert.Contains("0xfeed : TOO_LOW", consoleOutput.GetOutput());
        }
    }
}
