using SmartHomeHub.Devices;

namespace SmartHomeHub.Factories
{
	public interface IDeviceFactory
	{
		IDevice CreateDevice(string deviceType, string name);
	}
}