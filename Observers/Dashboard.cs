namespace SmartHomeHub.Observers
{
	public class Dashboard : IObserver//Dashboard visar enkelt vad som händer
	{
		public void Update(string deviceName, string action)
		{
			Console.WriteLine($"[DASHBOARD] {deviceName}: {action}");
		}
	}
}