namespace SmartHomeHub.Strategies
{
	public interface IModeStrategy
	{
		string ModeName { get; }
		bool CanTurnOnAllLights();
		double GetMaxTemperature();
	}
}