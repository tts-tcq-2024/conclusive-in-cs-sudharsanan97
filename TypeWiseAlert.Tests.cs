using NUnit.Framework;
using Moq;

namespace TypeWiseAlertTests
{
    public enum BreachType
    {
        TOO_LOW,
        TOO_HIGH,
        NORMAL
    }

    public enum CoolingType
    {
        PASSIVE_COOLING,
        HI_ACTIVE_COOLING
    }

    public class BatteryCharacter
    {
        public CoolingType CoolingType { get; set; }
        public string Dummy { get; set; } 
    }

    public static class TypeWiseAlert
    {
        public static BreachType Mock_classifyTemperatureBreach(CoolingType coolingType, double temperatureInC)
        {
            return BreachType.NORMAL;
        }

        public static void checkAndAlert(string recipient, BatteryCharacter batteryChar, double temperature)
        {
        }
    }

    public class TypeWiseAlertTestSuite
    {
        private static BreachType mockBreach;
        private static Func<CoolingType, double, BreachType> funcPtrClassifyTemperatureBreach;

        public void Setup()
        {
            funcPtrClassifyTemperatureBreach = TypeWiseAlert.Mock_classifyTemperatureBreach;
        }

        public void TestCheckAndAlert_TO_CONTROLLER_LowBreach()
        {
            mockBreach = funcPtrClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, -10);
            var expectedBreach = BreachType.TOO_LOW;
            var batteryChar = new BatteryCharacter { CoolingType = CoolingType.PASSIVE_COOLING, Dummy = " " };
            TypeWiseAlert.checkAndAlert("TO_CONTROLLER", batteryChar, -10);
            Assert.AreEqual(expectedBreach, mockBreach);
        }

        public void TestCheckAndAlert_TO_CONTROLLER_HighBreach()
        {
            mockBreach = funcPtrClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 50);
            var expectedBreach = BreachType.TOO_HIGH;
            var batteryChar = new BatteryCharacter { CoolingType = CoolingType.PASSIVE_COOLING, Dummy = " " };
            TypeWiseAlert.checkAndAlert("TO_CONTROLLER", batteryChar, 50);
            Assert.AreEqual(expectedBreach, mockBreach);
        }

        public void TestCheckAndAlert_TO_CONTROLLER_NormalBreach()
        {
            mockBreach = funcPtrClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 5);
            var expectedBreach = BreachType.NORMAL;
            var batteryChar = new BatteryCharacter { CoolingType = CoolingType.PASSIVE_COOLING, Dummy = " " };
            TypeWiseAlert.checkAndAlert("TO_CONTROLLER", batteryChar, 5);
            Assert.AreEqual(expectedBreach, mockBreach);
        }

        public void TestCheckAndAlert_TO_EMAIL_HighBreach()
        {
            mockBreach = funcPtrClassifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, 50);
            var expectedBreach = BreachType.TOO_HIGH;
            var batteryChar = new BatteryCharacter { CoolingType = CoolingType.HI_ACTIVE_COOLING, Dummy = " " };
            TypeWiseAlert.checkAndAlert("TO_EMAIL", batteryChar, 50);
            Assert.AreEqual(expectedBreach, mockBreach);
        }

        public void TestCheckAndAlert_TO_EMAIL_LowBreach()
        {
            mockBreach = funcPtrClassifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, -1);
            var expectedBreach = BreachType.TOO_LOW;
            var batteryChar = new BatteryCharacter { CoolingType = CoolingType.HI_ACTIVE_COOLING, Dummy = " " };
            TypeWiseAlert.checkAndAlert("TO_EMAIL", batteryChar, -1);
            Assert.AreEqual(expectedBreach, mockBreach);
        }

        public void TestCheckAndAlert_TO_EMAIL_NormalBreach()
        {
            mockBreach = funcPtrClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 5);
            var expectedBreach = BreachType.NORMAL;
            var batteryChar = new BatteryCharacter { CoolingType = CoolingType.PASSIVE_COOLING, Dummy = " " };
            TypeWiseAlert.checkAndAlert("TO_EMAIL", batteryChar, 10);
            Assert.AreEqual(expectedBreach, mockBreach);
        }

    }
}
