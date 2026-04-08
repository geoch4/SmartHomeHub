namespace SmartHomeHub.Devices
{
	public class Lamp : IDevice
	{
		public string Name { get; }
		public bool IsOn { get; private set; }
		private List<Observers.IObserver> _observers = new List<Observers.IObserver>();

		public Lamp(string name)
		{
			Name = name;
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
			IsOn = true;
			Console.WriteLine($"{Name} är tänd 💡");
			NotifyObservers("TurnOn");
		}

		public void TurnOff()
		{
			IsOn = false;
			Console.WriteLine($"{Name} är släckt");
			NotifyObservers("TurnOff");
		}
	}
}