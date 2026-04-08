namespace SmartHomeHub.Observers
{
	public class EventLogger : IObserver//EventLogger visar vad som händer men med en tidsstämpel (klockslag)
	{
		public void Update(string deviceName, string action)
		{
			Console.WriteLine($"[LOG] {DateTime.Now:HH:mm:ss} - {deviceName}: {action}");
		}
	}
}