using Microsoft.Azure.Devices.Client;
using SmartHealthMonitoring.Iot.DeviceSimulator.Helpers;
using SmartHealthMonitoring.Iot.SimulatorService.SimulatorServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace SmartHealthMonitoring.Iot.DeviceSimulator
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        private static DeviceClient _device;

        static async Task Main(string[] args)
        {
            _serviceProvider = DependencyHelper.RegisterServices(_serviceProvider);

            Console.WriteLine("Initializing Agent...");

            bool endTransfer = false; ;

            while (!endTransfer)
            {
                Console.WriteLine("Press a key to perform an action:");
                Console.WriteLine("h: Send Telemetry for Heart Rate");
                Console.WriteLine("q: End");
                var input = Console.ReadKey().KeyChar;

                if (char.ToLower(input) == 'q')
                    endTransfer = true;
                else
                    endTransfer = false;

                switch (char.ToLower(input))
                {
                    case 'h':
                        Console.WriteLine("Number of Telemetry Events to be Generated");
                        var numberOfTelemertry = Console.ReadLine();
                        int numberOfEvents;
                        int.TryParse(numberOfTelemertry, out numberOfEvents);
                        await SendHeartRateTelemetry(numberOfEvents);
                        break;

                    default:
                        break;
                }
            }
        }

        public static async Task SendHeartRateTelemetry(int numberOfTelemetryEvent)
        {
            var sendHeartTelemetry = _serviceProvider.GetService<IHeartRateTelemetryService>();
            var connectionStringHeartRate = Constants.HeartRateDeviceConnectionString;
            _device = DeviceClient.CreateFromConnectionString(connectionStringHeartRate);
            await sendHeartTelemetry.SendHeartTelemetryToCloud(_device, numberOfTelemetryEvent);
        }
    }

}
