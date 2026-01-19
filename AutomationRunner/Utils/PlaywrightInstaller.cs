using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationRunner.Utils;

public static class PlaywrightInstaller
{
    public static void EnsurePlaywrightInstalled()
    {
        var scriptPath = Path.Combine(
            AppContext.BaseDirectory,
            "playwright.ps1");

        if (!File.Exists(scriptPath))
        {
            Console.WriteLine("playwright.ps1 not found. Skipping install.");
            return;
        }

        Console.WriteLine("Ensuring Playwright browsers are installed...");

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "pwsh",
                Arguments = $"\"{scriptPath}\" install",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.Start();
        process.WaitForExit();
    }
}