using SmartHomeHub.Devices;

namespace SmartHomeHub.Commands
{
	public class SetTemperatureCommand : ICommand
	{
		private Thermostat _thermostat;
		private double _temperature;

		public SetTemperatureCommand(Thermostat thermostat, double temperature)
		{
			_thermostat = thermostat;
			_temperature = temperature;
		}

		public void Execute()
		{
			_thermostat.SetTemperature(_temperature);
		}
	}
}