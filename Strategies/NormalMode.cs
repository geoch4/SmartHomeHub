namespace SmartHomeHub.Strategies
{
	public class NormalMode : IModeStrategy
	{
		public string ModeName => "Normal Mode";

		public bool CanTurnOnAllLights()
		{
			return true;
		}

		public double GetMaxTemperature()
		{
			return 23;
		}
	}
}