public class MedActiveCooling : ICoolingStrategy
{
    public BreachType ClassifyTemperature(double temperatureInC) =>
        TypewiseAlert.InferBreach(temperatureInC, 0, 40);
}
