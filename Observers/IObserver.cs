namespace SmartHomeHub.Observers
{
	public interface IObserver
	{
		void Update(string deviceName, string action);
	}
}