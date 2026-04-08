namespace SmartHomeHub.Devices
{
	public interface IDevice
	{
		string Name { get; }
		void TurnOn();
		void TurnOff();
		void AddObserver(Observers.IObserver observer);
		void NotifyObservers(string action);
	}
}