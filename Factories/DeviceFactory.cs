using SmartHomeHub.Devices;

namespace SmartHomeHub.Factories
{
	public class DeviceFactory : IDeviceFactory
	{
		public IDevice CreateDevice(string deviceType, string name)
		{
			switch (deviceType.ToLower())
			{
				case "lamp":
					return new Lamp(name);

				case "thermostat":
					return new Thermostat(name);

				case "door":
					return new DoorLock(name);

				default:
					throw new ArgumentException("Unknown device type");
			}
		}
	}
}