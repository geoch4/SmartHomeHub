namespace SmartHomeHub.Commands
{
	public class CommandInvoker
	{
		private List<ICommand> _commands = new List<ICommand>();

		public void AddCommand(ICommand command)
		{
			_commands.Add(command);
		}

		public void RunAll()
		{
			Console.WriteLine("\n--- Kör alla kommandon ---");
			foreach (var command in _commands)
			{
				command.Execute();
			}
		}

		public void Replay()
		{
			Console.WriteLine("\n--- Replay! Kör om igen ---");
			foreach (var command in _commands)
			{
				command.Execute();
			}
		}
	}
}