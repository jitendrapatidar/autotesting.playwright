using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationRunner.Reporting;
public static class HtmlReportGenerator
{
    public static void Generate(string testName, bool status, string path)
    {
        Directory.CreateDirectory(path);

        File.WriteAllText(Path.Combine(path, $"{testName}.html"), $"""
        <html>
        <body style="font-family:Arial">
        <h2>Test: {testName}</h2>
        <h3>Status:
            <span style="color:{(status ? "green" : "red")}">
                {(status ? "PASSED" : "FAILED")}
            </span>
        </h3>
        <p>Executed: {DateTime.Now}</p>
        </body>
        </html>
        """);
    }
}