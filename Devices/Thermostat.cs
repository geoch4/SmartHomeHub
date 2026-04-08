namespace SmartHomeHub.Devices
{
	public class Thermostat : IDevice
	{
		public string Name { get; }
		public double Temperature { get; private set; }
		private List<Observers.IObserver> _observers = new List<Observers.IObserver>();

		public Thermostat(string name)
		{
			Name = name;
			Temperature = 20;
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
			Console.WriteLine($"{Name} är igång, temperatur: {Temperature}°C 🌡️");
			NotifyObservers("TurnOn");
		}

		public void TurnOff()
		{
			Console.WriteLine($"{Name} är avstängd");
			NotifyObservers("TurnOff");
		}

		public void SetTemperature(double temp)
		{
			Temperature = temp;
			Console.WriteLine($"{Name} satt till {Temperature}°C");
			NotifyObservers($"SetTemperature:{temp}");
		}
	}
}