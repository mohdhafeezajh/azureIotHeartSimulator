using Microsoft.Azure.Devices.Client;
using System.Threading.Tasks;

namespace SmartHealthMonitoring.Iot.SimulatorService.SimulatorServices
{
    public interface IHeartRateTelemetryService
    {
        Task<bool> SendHeartTelemetryToCloud(DeviceClient deviceClient, int numberOfTelemetryEvent);
    }
}
