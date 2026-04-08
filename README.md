# SmartHomeHub
Ett hem med smarta funktioner


## Hur man kör programmet
1. Öppna projektet i Visual Studio
2. Tryck Ctrl + F5 för att köra

## Designmönster

### Observer 👁️
**Var:** `Observers/IObserver.cs`, `Dashboard.cs`, `EventLogger.cs`, `AuditLog.cs`
**Problem:** När en enhet ändrar state behövde flera delar av systemet få veta det automatiskt.
**Lösning:** Dashboard, EventLogger och AuditLog prenumererar på enheter och får automatiskt notis när något händer. Dashboard visar enkelt vad som händer, EventLogger loggar med klockslag, AuditLog sparar en historik.

### Command 🎛️
**Var:** `Commands/ICommand.cs`, `TurnOnCommand.cs`, `TurnOffCommand.cs`, `SetTemperatureCommand.cs`, `CommandInvoker.cs`
**Problem:** Handlingar behövde kunna sparas, köas och köras om.
**Lösning:** Varje handling är ett objekt. CommandInvoker kan köra alla kommandon i ordning och även köra om dem med Replay().

### Strategy 🧠
**Var:** `Strategies/IModeStrategy.cs`, `EcoMode.cs`, `NormalMode.cs`, `PartyMode.cs`
**Problem:** Systemet behövde bete sig olika beroende på vilket läge som är aktivt.
**Lösning:** Varje läge är en utbytbar algoritm. EcoMode begränsar temperatur och blockerar lampor och kommandon, PartyMode tillåter mer. Strategy påverkar både MorningRoutine och RunCommandIfAllowed.

### Facade 🧱
**Var:** `Core/SmartHomeFacade.cs`
**Problem:** Program.cs skulle annars behöva känna till alla detaljer i systemet.
**Lösning:** SmartHomeFacade ger ett rent API med metoder som AddDevice(), SetMode(), RunCommand() och MorningRoutine().

### Singleton 🧩
**Var:** `Core/AppLogger.cs`
**Problem:** Flera delar av systemet behövde logga till samma logg.
**Lösning:** AppLogger.Instance returnerar alltid samma instans, oavsett varifrån den anropas. Bevisas med "Samma logger? True" i output.

## Demo output
- Samma logger? True
- NormalMode: Lampan tänds, termostat sätts till 23°C
- EcoMode: Lampan blockeras, termostat max 19°C, kommandon blockeras
- PartyMode: Allt tillåts, termostat u