using System;
using System.Device.Gpio;
using System.Threading;

namespace Raspberry_Pi_App
{
    class GpioTest
    {
        static void Main(string[] args)
        {
            int pinNumber = 17; // Exempelpin, ändra om nödvändigt

            try
            {
                using (GpioController controller = new GpioController())
                {
                    if (controller.IsPinOpen(pinNumber))
                    {
                        Console.WriteLine($"Pin {pinNumber} är redan öppen.");
                        return;
                    }

                    controller.OpenPin(pinNumber, PinMode.Output);
                    Console.WriteLine($"Pin {pinNumber} öppnad.");

                    controller.Write(pinNumber, PinValue.High);
                    Console.WriteLine($"Pin {pinNumber} satt till HIGH.");

                    Thread.Sleep(5000); // Vänta i 5 sekunder

                    controller.Write(pinNumber, PinValue.Low);
                    Console.WriteLine($"Pin {pinNumber} satt till LOW.");

                    controller.ClosePin(pinNumber);
                    Console.WriteLine($"Pin {pinNumber} stängd.");
                }

                Console.WriteLine("Testet är klart.");
            }
            catch (Exception ex)
            {
                // Skriv ut detaljerat felmeddelande i konsolen
                Console.WriteLine($"Ett oväntat fel uppstod: {ex.Message}");
                // Vänta i 5 sekunder innan programmet stänger sig
                Thread.Sleep(5000);
            }
        }
    }
}
