using AutomationRunner.Parsers;
using AutomationRunner.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationRunner.Core;

public class AutomationEngine
{
    public async Task RunAsync()
    {
        //CALL ONCE HERE
        PlaywrightInstaller.EnsurePlaywrightInstalled();

        var config = ConfigHelper.Load();

        string testFolder = config["AutomationSettings:TestCaseFolderPath"]!;
        string resultFolder = config["AutomationSettings:ResultFolderPath"]!;

        // Convert relative paths to absolute paths
        string testFolderPath = Path.GetFullPath(testFolder);
        string resultFolderPath = Path.GetFullPath(resultFolder);

        // 1️⃣ Ensure folders exist
        if (!Directory.Exists(testFolderPath))
        {
            Directory.CreateDirectory(testFolderPath);
            Console.WriteLine($"TestCases folder created at: {testFolderPath}");
        }

        if (!Directory.Exists(resultFolderPath))
        {
            Directory.CreateDirectory(resultFolderPath);
            Directory.CreateDirectory(Path.Combine(resultFolderPath, "Reports"));
            Directory.CreateDirectory(Path.Combine(resultFolderPath, "Logs"));
            Directory.CreateDirectory(Path.Combine(resultFolderPath, "Screenshots"));
            Console.WriteLine($"Results folder created at: {resultFolderPath}");
        }

        // 2️⃣ Check if any .txt test files exist
        var testFiles = Directory.GetFiles(testFolderPath, "*.txt");

        if (testFiles.Length == 0)
        {
            Console.WriteLine("❌ No test case files found in TestCases folder!");
            Console.WriteLine($"Please create a test file, e.g., '{Path.Combine(testFolderPath, "txt")}'");
            return; // stop execution
        }

        // 3️⃣ Execute all test files
        foreach (var file in testFiles)
        {
            var steps = TextTestParser.Parse(file);
            var executor = new StepExecutor(config);
            await executor.ExecuteAsync(steps, Path.GetFileNameWithoutExtension(file));
        }
    }
}
//public class AutomationEngine
//{

//    public async Task RunAsync()
//    {
//        //CALL ONCE HERE
//        PlaywrightInstaller.EnsurePlaywrightInstalled();

//        var config = ConfigHelper.Load();
//        var testPath = config["AutomationSettings:TestCaseFolderPath"];

//        var files = Directory.GetFiles(testPath!, "*.txt");

//        foreach (var file in files)
//        {
//            var steps = TextTestParser.Parse(file);
//            var executor = new StepExecutor(config);
//            await executor.ExecuteAsync(
//                steps,
//                Path.GetFileNameWithoutExtension(file));
//        }
//    }

//}

