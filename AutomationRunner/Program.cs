
using AutomationRunner.Core;
Console.WriteLine("Hello, World!");
Console.WriteLine("====================================");
Console.WriteLine(" Inspectra Automation Testing Tool ");
Console.WriteLine("====================================");
 var engine = new AutomationEngine();
Console.WriteLine("Start AutomationEngine ");
await engine.RunAsync();
Console.WriteLine("End Inspectra Automation Engine ");
Console.WriteLine("Execution completed.");
