using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Temperature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UsefullClasses
{
    public class CommandsHandler
    {
        Dictionary<string, Action> VoidCommands; //dictionary with completely void methods
        Dictionary<string, Action<byte>> ByteCommands; //dictionary with methods that accepts byte values but are void
        Dictionary<string, Action<byte[]>> ByteArrayCommands; //dictionary with methods that accepts byte array values but are void
        Dictionary<string, Action<AirConditioner.AirTypeList, float, byte>> AcCommands; //dictionary with methods that accepts AirType, float, byte and returns void (Air conditioner)
        Dictionary<string, Func<bool>> BoolReturnCommands; //dictionary with methods that returns bool values
        Dictionary<string, Func<AirFryer.CookingType, byte, Time, Task>> AirFryerCommands; //dictionary with methods that accepts CookingType, byte, Time and returns Task (Air fryer)

        public CommandsHandler(Lamp Lamp1, EcoLamp EcoLamp1, TwoLampDevice TwoLampDevice1, Thermostat Thermostat1, AirConditioner AirConditioner1, AirFryer AirFryer1, CCTV Camera1, Door Door1)
        {
            try
            {
                VoidCommands = new Dictionary<string, Action>() {
                    {"change both lamp state", TwoLampDevice1.ChangeBothLampState },
                    {"change lamp1 state", TwoLampDevice1.ChangeLamp1State },
                    {"change ecolamp1 state", TwoLampDevice1.ChangeLamp2State },
                    {"change both lamps brightness", () => {
                        Console.WriteLine("Enter lamp brightness(1-100): ");
                        byte lamp1Brightness = byte.Parse(Console.ReadLine());
                        Console.WriteLine("Enter ecolamp brightness(1-65): ");
                        byte ecolamp1Brightness = byte.Parse(Console.ReadLine());
                        TwoLampDevice1.ChangeBothLampBrightness(lamp1Brightness, ecolamp1Brightness);}},
                    {"display current temperature", Thermostat1.DisplayCurrentTemperature },
                    {"start recording", Camera1.StartRecording },
                    {"stop camera1 recording", Camera1.StopRecording },
                    {"stop air fryer1", AirFryer1.StopTheCooking }
                };

                ByteCommands = new Dictionary<string, Action<byte>>() {
                    {"change lamp1 brightness", Lamp1.ChangeBrightness},
                    {"change ecolamp1 brightness", EcoLamp1.ChangeBrightness},
                    {"increase thermostat1 setpoint temperature", Thermostat1.IncreaseSetpointTemperature },
                    {"decrease thermostat1 setpoint temperature", Thermostat1.DecreaseSetpointTemperature }
                };

                ByteArrayCommands = new Dictionary<string, Action<byte[]>>() {
                    {"change lamp1 color", TwoLampDevice1.ChangeLamp1Color }
                };

                BoolReturnCommands = new Dictionary<string, Func<bool>>() {
                    {"turn on lamp1", Lamp1.TurnOnOrOff },
                    {"turn off lamp1", Lamp1.TurnOnOrOff },
                    {"turn on ecolamp1", EcoLamp1.TurnOnOrOff },
                    {"turn off ecolamp1", EcoLamp1.TurnOnOrOff },
                    {"turn on thermostat1", Thermostat1.TurnOnOrOff },
                    {"turn off thermostat1", Thermostat1.TurnOnOrOff },
                    {"turn on air conditioner1", AirConditioner1.TurnOnOrOff },
                    {"turn off air conditioner1", AirConditioner1.TurnOnOrOff },
                    {"turn on camera1", Camera1.TurnOnOrOff },
                    {"turn of camera1", Camera1.TurnOnOrOff },
                    {"lock the door1", Door1.LockUnlockTheDoor },
                    {"unlock the door1", Door1.LockUnlockTheDoor }
                };

                AirFryerCommands = new Dictionary<string, Func<AirFryer.CookingType, byte, Time, Task>>() {
                    {"start air fryer1", AirFryer1.StartTheCooking }
                };

                AcCommands = new Dictionary<string, Action<AirConditioner.AirTypeList, float, byte>>() {
                    {"start air conditioner1", AirConditioner1.StartAirConditioner }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        public async Task Process(string command)
        {
            try
            {
                if (VoidCommands.TryGetValue(command, out var voidAction))
                    voidAction();
                else if (ByteCommands.TryGetValue(command, out var byteAction))
                {
                    Console.WriteLine("Enter value:");
                    byte ByteValue = byte.Parse(Console.ReadLine());
                    byteAction(ByteValue);
                }
                else if (BoolReturnCommands.TryGetValue(command, out var boolFunc))
                    boolFunc();
                else if (ByteArrayCommands.TryGetValue(command, out var byteArrayAction))
                {
                    Console.WriteLine("Enter three byte values for RGB color (0-255) separated by spaces: ");
                    string input = Console.ReadLine();
                    byte[] byteArray = input.Split(' ').Select(byte.Parse).ToArray();
                    if (byteArray.Length != 3)
                    {
                        Console.WriteLine("Invalid input. Please enter exactly three byte values.");
                        return;
                    }
                    byteArrayAction(byteArray);
                }
                else if (AcCommands.TryGetValue(command, out var acAction))
                {
                    // Let the user choose air type
                    Console.WriteLine("Choose air type: Cool, Heat, Fan, auto, Dry");
                    string typeInput = Console.ReadLine();
                    if (!Enum.TryParse(typeInput, true, out AirConditioner.AirTypeList airType))
                    {
                        Console.WriteLine("Invalid air type");
                        return;
                    }

                    Console.WriteLine("Enter temperature:");
                    float temperature = float.Parse(Console.ReadLine());

                    Console.WriteLine("Enter speed (1-100):");
                    byte speed = byte.Parse(Console.ReadLine());

                    acAction(airType, temperature, speed);
                    Console.WriteLine("Air conditioner started!");
                }
                else if (AirFryerCommands.TryGetValue(command, out var airFryerFunc))
                {
                    // Let the user choose cooking type
                    Console.WriteLine("Choose cooking type: Null, Fryed, Roasted, Sweets, Grilled, Dehydrated, Baked, Dryed, SlowCooked, Steamed, Pizza, Reheated, Tosted, KeepWarmed, Pasta");
                    string cookingInput = Console.ReadLine();
                    if (!Enum.TryParse(cookingInput, true, out AirFryer.CookingType cookingType))
                    {
                        Console.WriteLine("Invalid cooking type");
                        return;
                    }

                    Console.WriteLine("Enter temperature(80-200):");
                    byte temperature = byte.Parse(Console.ReadLine());

                    Console.WriteLine("Enter duration in minutes:");
                    int minutes = int.Parse(Console.ReadLine());
                    Time duration = new Time(0, minutes, 0);

                    await airFryerFunc(cookingType, temperature, duration);
                    Console.WriteLine("Cooking started!");
                }
                else if (string.IsNullOrWhiteSpace(command))
                    Console.WriteLine("No command entered");
                else
                    Console.WriteLine("Command not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}