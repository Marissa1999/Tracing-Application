using System;
using System.Diagnostics.Tracing;

namespace Tracing
{

    class Program
    {
        static void Main(string[] args)
        {
            //-1- Instantiate the EventSource class.
            EventSource sampleEventSource = new EventSource("VanierEventSource");

            //-2- Generate a GUID in order to use it in the logging session.
            Console.WriteLine($"Log Guid: {sampleEventSource.Guid}");
            Console.WriteLine($"Name: {sampleEventSource.Name}");

            //-3- Create a log event to mention that the application started.
            sampleEventSource.Write("Startup", new { Info = "Application Started" });

            //-4- Mark the log with a call to calculate.
            sampleEventSource.Write("Action", new { Info = $"Calling Calculate" });
            int result = calculate(10, 2);

            //-5- Mark the end of the calculation action.
            sampleEventSource.Write("Action Complete", new { Info = $"Completed Call to Calculate, Result: {result}" });

            //-6- Mark the end of the application.
            sampleEventSource.Write("Complete", new { Info = "Application Done" });
            Console.WriteLine("Completed, press any key to exit.");
            Console.ReadLine();

            //-7- Need to cleanup.
            sampleEventSource.Dispose();

        }

        static int calculate(int a, int b)
        {
            return a / b;
        }
    }
}
