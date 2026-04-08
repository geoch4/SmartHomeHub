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

// Skapa observers
var dashboard = new Dashboard();
var eventLogger = new EventLogger();

// Lägg till observers på enheterna
lamp.AddObserver(dashboard);
lamp.AddObserver(eventLogger);
thermostat.AddObserver(dashboard);
thermostat.AddObserver(eventLogger);
door.AddObserver(dashboard);
door.AddObserver(eventLogger);

// Skapa Facade
var hub = new SmartHomeFacade();
hub.AddDevice(lamp);
hub.AddDevice(thermostat);
hub.AddDevice(door);

// Strategy - testa olika lägen
Console.WriteLine("--- Testar NormalMode ---");
hub.SetMode(new NormalMode());
hub.MorningRoutine(lamp, thermostat, door);

Console.WriteLine("--- Testar EcoMode ---");
hub.SetMode(new EcoMode());
hub.MorningRoutine(lamp, thermostat, door);

Console.WriteLine("--- Testar PartyMode ---");
hub.SetMode(new PartyMode());
hub.MorningRoutine(lamp, thermostat, door);

//// ✅ Singleton – "Samma logger? True"
//✅ Observer – Dashboard och Logger reagerar
//✅ Command – kommandon körs via Facade
//✅ Strategy – olika lägen ger olika beteende
//✅ Facade – allt styrs via hub