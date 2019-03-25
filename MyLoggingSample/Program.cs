using Common.Logging;
using log4net.Config;
using Serilog;
using System;

namespace MyLoggingSample
{

    class Program
    {
        

        static void Main(string[] args)
        {
            /*
            var test = new TestLogger();
            test.TestMe();
            */
            Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs\\myappTest.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

        var  Logger = LogManager.GetLogger(typeof(Program));


        //XmlConfigurator.Configure();

        Logger.Info("Hello, world!");

            int a = 10, b = 0;
            try
            {
                Logger.DebugFormat("Dividing {A} by {B}", a, b);
                Console.WriteLine(a / b);
            }
            catch (Exception ex)
            {
                Logger.Error("Something went wrong", ex);
            }

            Console.ReadKey();
            
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
