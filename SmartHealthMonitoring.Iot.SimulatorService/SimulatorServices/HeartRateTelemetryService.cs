using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using SmartHealthMonitoring.Telemetry.Models;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthMonitoring.Iot.SimulatorService.SimulatorServices
{
    public class HeartRateTelemetryService : IHeartRateTelemetryService
    {
        public async Task<bool> SendHeartTelemetryToCloud(DeviceClient deviceClient, int numberOfTelemetryEvent)
        {
            try
            {
                 Random rand = new Random();
                for (int i = 0; i < numberOfTelemetryEvent; i++)
                {
                    var sendHeartRateTelemetry = new HeartRateTelemetry
                    {

                        EventDate = DateTime.Now,
                        Tag = "bpm",
                        HeartRate = rand.Next(44, 164),
                        SensorId = "heartrateSensor"
                    };

                    var payload = JsonConvert.SerializeObject(sendHeartRateTelemetry);
                    var message = new Message(Encoding.ASCII.GetBytes(payload));
                    await deviceClient.SendEventAsync(message);


                }
                Console.WriteLine("Heart Rate Telemetry Simulation Completed");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured" + ex.StackTrace);

                return false;
            }
        }
    }
}
