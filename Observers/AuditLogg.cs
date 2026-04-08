namespace SmartHomeHub.Observers
{
	public class AuditLog : IObserver//AuditLog – sparar en historik som du kan visa i efterhand med ShowHistory()
	{
		private List<string> _log = new List<string>();

		public void Update(string deviceName, string action)
		{
			string entry = $"[AUDIT] {DateTime.Now:yyyy-MM-dd HH:mm:ss} | Enhet: {deviceName} | Händelse: {action}";
			_log.Add(entry);
			Console.WriteLine(entry);
		}

		public void ShowHistory()
		{
			Console.WriteLine("\n--- Audit Historik ---");
			foreach (var entry in _log)
			{
				Console.WriteLine(entry);
			}
		}
	}
}