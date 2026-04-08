namespace SmartHomeHub.Strategies
{
	public class EcoMode : IModeStrategy
	{
		public string ModeName => "Eco Mode 🌿";

		public bool CanTurnOnAllLights()
		{
			return false; // Spara energi!
		}

		public double GetMaxTemperature()
		{
			return 19; // Max 19 grader
		}
	}
}