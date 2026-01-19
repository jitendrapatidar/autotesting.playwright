using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationRunner.Utils;

public static class Logger
{
    public static void Log(string testName, string message, IConfiguration config)
    {
        var logDir = Path.Combine(
            config["AutomationSettings:ResultFolderPath"]!,
            "Logs");

        Directory.CreateDirectory(logDir);

        File.AppendAllText(
            Path.Combine(logDir, $"{testName}.log"),
            $"{DateTime.Now}: {message}\n");
    }
}