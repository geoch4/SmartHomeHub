using SmartHomeHub.Devices;
using SmartHomeHub.Observers;
using SmartHomeHub.Commands;
using SmartHomeHub.Strategies;
using SmartHomeHub.Core;

Console.WriteLine("=== Smart Home Hub ===\n");

// Singleton - samma logger används överallt
var logger1 = AppLogger.Instance;
var logger2 = AppLogger.Instance;
Console.WriteLine($"Samma logger? {object.ReferenceEquals(logger1, logger2)}\n");

// Skapa enheter
var lamp = new Lamp("Vardagsrumslampa");
var thermostat = new Thermostat("Termostat");
var door = new DoorLock("Ytterdörr");

// Skapa observers - nu 3 st med olika ansvar!
var dashboard = new Dashboard();
var eventLogger = new EventLogger();
var audit = new AuditLog();

// Lägg till observers på alla enheter
lamp.AddObserver(dashboard);
lamp.AddObserver(eventLogger);
lamp.AddObserver(audit);

thermostat.AddObserver(dashboard);
thermostat.AddObserver(eventLogger);
thermostat.AddObserver(audit);

door.AddObserver(dashboard);
door.AddObserver(eventLogger);
door.AddObserver(audit);

// Skapa Facade
var hub = new SmartHomeFacade();
hub.AddDevice(lamp);
hub.AddDevice(thermostat);
hub.AddDevice(door);

// Strategy påverkar morgonrutin
Console.WriteLine("--- Testar NormalMode ---");
hub.SetMode(new NormalMode());
hub.MorningRoutine(lamp, thermostat, door);

Console.WriteLine("--- Testar EcoMode ---");
hub.SetMode(new EcoMode());
hub.MorningRoutine(lamp, thermostat, door);

Console.WriteLine("--- Testar PartyMode ---");
hub.SetMode(new PartyMode());
hub.MorningRoutine(lamp, thermostat, door);

// Strategy påverkar även enskilda kommandon
Console.WriteLine("--- Strategy påverkar RunCommand ---");
hub.SetMode(new EcoMode());
bool allowed = hub.RunCommandIfAllowed(new TurnOnCommand(lamp));
if (!allowed)
{
	Console.WriteLine("EcoMode blockerade kommandot!");
}

hub.SetMode(new NormalMode());
hub.RunCommand(new TurnOnCommand(lamp));

// Visa audit historik
audit.ShowHistory();