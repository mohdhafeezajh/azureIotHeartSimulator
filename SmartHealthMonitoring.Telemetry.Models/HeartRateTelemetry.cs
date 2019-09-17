using System;

namespace SmartHealthMonitoring.Telemetry.Models
{
    public class HeartRateTelemetry
    {
        public double HeartRate { get; set; }
        public DateTime EventDate { get; set; }
        public string  SensorId { get; set; }
        public string Tag { get; set; }
        public string DeviceId { get; set; }
    }
}
