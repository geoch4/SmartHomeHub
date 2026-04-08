namespace SmartHomeHub.Devices
{
	public class DoorLock : IDevice
	{
		public string Name { get; }
		public bool IsLocked { get; private set; }
		private List<Observers.IObserver> _observers = new List<Observers.IObserver>();

		public DoorLock(string name)
		{
			Name = name;
			IsLocked = true;
		}

		public void AddObserver(Observers.IObserver observer)
		{
			_observers.Add(observer);
		}

		public void NotifyObservers(string action)
		{
			foreach (var observer in _observers)
			{
				observer.Update(Name, action);
			}
		}

		public void TurnOn()
		{
			IsLocked = true;
			Console.WriteLine($"{Name} är låst 🔒");
			NotifyObservers("Locked");
		}

		public void TurnOff()
		{
			IsLocked = false;
			Console.WriteLine($"{Name} är upplåst 🔓");
			NotifyObservers("Unlocked");
		}
	}
}