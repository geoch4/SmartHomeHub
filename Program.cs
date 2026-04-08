using SmartHomeHub.Devices;
using SmartHomeHub.Observers;
using SmartHomeHub.Commands;
using SmartHomeHub.Strategies;
using SmartHomeHub.Core;
using SmartHomeHub.Factories;

Console.WriteLine("=== Smart Home Hub ===\n");

// =======================
// Singleton test
// =======================
var logger1 = AppLogger.Instance;
var logger2 = AppLogger.Instance;

Console.WriteLine($"Samma logger? {object.ReferenceEquals(logger1, logger2)}\n");

// =======================
// Factory - skapa enheter
// =======================
var factory = new DeviceFactory();

var lamp = factory.CreateDevice("lamp", "Vardagsrumslampa");
var thermostat = factory.CreateDevice("thermostat", "Termostat") as Thermostat;
var door = factory.CreateDevice("door", "Ytterdörr") as DoorLock;

// =======================
// Observers
// =======================
var dashboard = new Dashboard();
var eventLogger = new EventLogger();
var audit = new AuditLog();

// Lägg till observers
lamp.AddObserver(dashboard);
lamp.AddObserver(eventLogger);
lamp.AddObserver(audit);

thermostat.AddObserver(dashboard);
thermostat.AddObserver(eventLogger);
thermostat.AddObserver(audit);

door.AddObserver(dashboard);
door.AddObserver(eventLogger);
door.AddObserver(audit);

// =======================
// Facade
// =======================
var hub = new SmartHomeFacade();

hub.AddDevice(lamp);
hub.AddDevice(thermostat);
hub.AddDevice(door);

// =======================
// Strategy + Facade
// =======================
Console.WriteLine("--- Testar NormalMode ---");
hub.SetMode(new NormalMode());
hub.MorningRoutine(lamp as Lamp, thermostat, door);

Console.WriteLine("--- Testar EcoMode ---");
hub.SetMode(new EcoMode());
hub.MorningRoutine(lamp as Lamp, thermostat, door);

Console.WriteLine("--- Testar PartyMode ---");
hub.SetMode(new PartyMode());
hub.MorningRoutine(lamp as Lamp, thermostat, door);

// =======================
// Command via Facade
// =======================
Console.WriteLine("--- Strategy påverkar RunCommand ---");

hub.SetMode(new EcoMode());
bool allowed = hub.RunCommandIfAllowed(new TurnOnCommand(lamp));

if (!allowed)
{
	Console.WriteLine("EcoMode blockerade kommandot!");
}

hub.SetMode(new NormalMode());
hub.RunCommand(new TurnOnCommand(lamp));

// =======================
// Visa Audit historik
// =======================
audit.ShowHistory();