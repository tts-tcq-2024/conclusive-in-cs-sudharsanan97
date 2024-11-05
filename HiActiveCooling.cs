public class HiActiveCooling : ICoolingStrategy
{
    public BreachType ClassifyTemperature(double temperatureInC) =>
        TypewiseAlert.InferBreach(temperatureInC, 0, 45);
}
