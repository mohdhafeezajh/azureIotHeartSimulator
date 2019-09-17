using Microsoft.Extensions.DependencyInjection;
using SmartHealthMonitoring.Iot.SimulatorService.SimulatorServices;
using System;

namespace SmartHealthMonitoring.Iot.DeviceSimulator.Helpers
{
    public static class DependencyHelper
    {
        public static IServiceProvider RegisterServices(IServiceProvider _serviceProvider)
        {

            var collection = new ServiceCollection();
            collection.AddTransient<IHeartRateTelemetryService, HeartRateTelemetryService>();
            _serviceProvider = collection.BuildServiceProvider();
            return _serviceProvider;
        }

        public static void DisposeServices(IServiceProvider _serviceProvider)
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
