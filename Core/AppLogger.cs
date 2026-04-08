namespace SmartHomeHub.Core
{
	public class AppLogger
	{
		private static AppLogger? _instance;

		private AppLogger() { }

		public static AppLogger Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new AppLogger();
				}
				return _instance;
			}
		}

		public void Log(string message)
		{
			Console.WriteLine($"[APPLOGGER] {DateTime.Now:HH:mm:ss} - {message}");
		}
	}
}
//private AppLogger() – ingen kan skapa en ny instans utifrån
//_instance – den enda instansen som finns
//Instance – alla som vill ha loggern får samma instans tillbaka
//Det spelar ingen roll hur många klasser som anropar AppLogger.Instance – de får alltid samma objekt!