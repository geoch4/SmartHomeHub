# Smart Home Hub 🏠

## Hur man kör programmet
1. Öppna projektet i Visual Studio
2. Tryck Ctrl + F5 för att köra

## Designmönster

### Observer 👁️
**Var:** `Observers/IObserver.cs`, `Dashboard.cs`, `EventLogger.cs`, `AuditLog.cs`  
**Problem:** När en enhet ändrar state behövde flera delar av systemet få veta det automatiskt.  
**Lösning:** Dashboard, EventLogger och AuditLog prenumererar på enheter och får automatiskt notis när något händer. Dashboard visar vad som händer just nu, EventLogger loggar med tidsstämpel och AuditLog sparar historik.

### Command 🎛️
**Var:** `Commands/ICommand.cs`, `TurnOnCommand.cs`, `TurnOffCommand.cs`, `SetTemperatureCommand.cs`, `CommandInvoker.cs`  
**Problem:** Handlingar behövde kunna kapslas in, sparas och köras om.  
**Lösning:** Varje handling är ett kommando-objekt. `CommandInvoker` kan köra kommandon i ordning och även köra dem igen med `Replay()`.

### Strategy 🧠
**Var:** `Strategies/IModeStrategy.cs`, `EcoMode.cs`, `NormalMode.cs`, `PartyMode.cs`  
**Problem:** Systemet behövde bete sig olika beroende på vilket läge som är aktivt.  
**Lösning:** Varje läge är en egen strategi. EcoMode begränsar temperatur och kan blockera vissa kommandon, medan PartyMode tillåter mer. Strategin påverkar både `MorningRoutine()` och `RunCommandIfAllowed()`.

### Facade 🧱
**Var:** `Core/SmartHomeFacade.cs`  
**Problem:** `Program.cs` skulle annars behöva känna till för många detaljer i systemet.  
**Lösning:** `SmartHomeFacade` ger ett enklare API med metoder som `AddDevice()`, `SetMode()`, `RunCommand()` och `MorningRoutine()`.

### Singleton 🧩
**Var:** `Core/AppLogger.cs`  
**Problem:** Flera delar av systemet behövde använda samma logger.  
**Lösning:** `AppLogger.Instance` returnerar alltid samma instans. Detta visas i programmet med utskriften `Samma logger? True`.

### Factory Method 🏭
**Var:** `Factories/IDeviceFactory.cs`, `Factories/DeviceFactory.cs`  
**Problem:** Skapandet av enheter skulle annars ligga direkt i `Program.cs` med flera `new`-anrop.  
**Lösning:** En separat factory ansvarar för att skapa rätt typ av enhet baserat på input, till exempel `"lamp"`, `"thermostat"` eller `"door"`. Det gör koden mer samlad, tydligare och lättare att bygga ut med fler enheter i framtiden.

## Demo output
- Samma logger? True
- NormalMode: lampan tänds och temperaturen sätts till normal nivå
- EcoMode: lampan kan blockeras och temperaturen begränsas
- PartyMode: högre temperatur tillåts
- Dashboard, EventLogger och AuditLog reagerar på händelser
- Audit historik visas i slutet

## Reflektion – när ska man INTE använda designmönster?

Designmönster är verktyg, inte regler. De kan lösa riktiga problem, men de kan också göra enkel kod onödigt komplex.

**Observer** behövs inte om bara en del av systemet behöver reagera på en händelse. Då räcker ett vanligt metodanrop.

**Command** är onödigt om man aldrig behöver spara, köa eller köra om handlingar.

**Strategy** ska inte användas om beteendet aldrig varierar i praktiken.

**Facade** kan bli ett onödigt extra lager om systemet är väldigt litet.

**Singleton** kan göra koden svårare att testa eftersom den skapar global state.

**Factory Method** behövs inte om objekt skapats på ett väldigt enkelt sätt och det bara finns en enda typ att skapa.

**Slutsats:** Man ska använda designmönster när de löser ett konkret problem, inte bara för att göra koden mer avancerad.