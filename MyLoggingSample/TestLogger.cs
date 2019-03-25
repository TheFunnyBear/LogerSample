using Serilog;
using System;

namespace MyLoggingSample
{
    public sealed class TestLogger
    {
        public void TestMe()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Hello, world!");

            var count = 456;
            Log.Information("Retrieved {Count} records", count);

            var unknown = new[] { 1, 2, 3 };
            Log.Information("Received {$Data}", unknown);
            Log.Information("Received {Data}", unknown);
            Log.Information("Received {@Data}", unknown);

            var fruit = new[] { "Apple", "Pear", "Orange" };
            Log.Information("In my bowl I have {Fruit}", fruit);

            var sensorInput = new { Latitude = 25, Longitude = 134 };
            Log.Information("Processing {@SensorInput}", sensorInput);

            int a = 10, b = 0;
            try
            {
                Log.Debug("Dividing {A} by {B}", a, b);
                Console.WriteLine(a / b);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");
            }

            Log.CloseAndFlush();
            Console.ReadKey();
        }
    }
}
