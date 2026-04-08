using SmartHomeHub.Devices;

namespace SmartHomeHub.Commands
{
	public class TurnOnCommand : ICommand
	{
		private IDevice _device;

		public TurnOnCommand(IDevice device)
		{
			_device = device;
		}

		public void Execute()
		{
			_device.TurnOn();
		}
	}
}