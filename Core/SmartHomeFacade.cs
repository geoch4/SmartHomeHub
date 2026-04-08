using SmartHomeHub.Devices;
using SmartHomeHub.Observers;
using SmartHomeHub.Commands;
using SmartHomeHub.Strategies;

namespace SmartHomeHub.Core
{
	public class SmartHomeFacade
	{
		private List<IDevice> _devices = new List<IDevice>();
		private CommandInvoker _invoker = new CommandInvoker();
		private IModeStrategy _mode = new NormalMode();
		private AppLogger _logger = AppLogger.Instance;

		public void AddDevice(IDevice device)
		{
			_devices.Add(device);
			_logger.Log($"Enhet tillagd: {device.Name}");
		}

		public void SetMode(IModeStrategy mode)
		{
			_mode = mode;
			_logger.Log($"Mode ändrat till: {mode.ModeName}");
			Console.WriteLine($"Mode är nu: {mode.ModeName}");
		}

		public void RunCommand(ICommand command)
		{
			_invoker.AddCommand(command);
			command.Execute();
		}

		public void MorningRoutine(Lamp lamp, Thermostat thermostat, DoorLock door)
		{
			Console.WriteLine("\n--- Morgonrutin startar ---");
			_logger.Log("Morgonrutin startar");

			if (_mode.CanTurnOnAllLights())
			{
				lamp.TurnOn();
			}
			else
			{
				Console.WriteLine("Eco Mode: Lampan tänds inte!");
			}

			if (thermostat != null)
			{
				double maxTemp = _mode.GetMaxTemperature();
				thermostat.SetTemperature(maxTemp);
			}

			door.TurnOff();
			Console.WriteLine("--- Morgonrutin klar ---\n");
		}
	}
}
//Vad gör Facade?

//AddDevice – lägger till en enhet i systemet
//SetMode – byter läge (Eco, Normal, Party)
//RunCommand – kör ett kommando
//MorningRoutine – kör flera saker på en gång