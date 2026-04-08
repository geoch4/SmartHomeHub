namespace SmartHomeHub.Strategies
{
	public class PartyMode : IModeStrategy
	{
		public string ModeName => "Party Mode 🎉";

		public bool CanTurnOnAllLights()
		{
			return true; // Tänd allt!
		}

		public double GetMaxTemperature()
		{
			return 26; // Varmare är okej!
		}
	}
}