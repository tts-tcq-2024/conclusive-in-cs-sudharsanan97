public class PassiveCooling : ICoolingStrategy
{
    public BreachType ClassifyTemperature(double temperatureInC) =>
        TypewiseAlert.InferBreach(temperatureInC, 0, 35);
}
