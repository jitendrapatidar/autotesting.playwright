using AutomationRunner.Reporting;
using AutomationRunner.Utils;
using AutomationRunner.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationRunner.Core;

public class StepExecutor
{
    private readonly IConfiguration _config;

    public StepExecutor(IConfiguration config)
    {
        _config = config;
    }

    public async Task ExecuteAsync(string[] steps, string testName)
    {
        bool passed = true;

        using var playwright = await Playwright.CreateAsync();
        
        //var browser = await playwright.Chromium.LaunchAsync(
        //    new() { Headless = bool.Parse(_config["AutomationSettings:Headless"]!) });
        var browser = await playwright.Chromium.LaunchAsync(new()
        {
            Channel = "chrome",   // or "msedge"
            Headless = bool.Parse(_config["AutomationSettings:Headless"]!)
        });
        var page = await browser.NewPageAsync();

        try
        {
            foreach (var step in steps)
            {
                KeywordValidator.Validate(step);
                var parts = step.Split(' ', 3);

                switch (parts[0].ToLower())
                {
                    case "goto":
                        await page.GotoAsync(parts[1]);
                        break;
                    case "fill":
                        await page.FillAsync(parts[1], parts[2]);
                        break;
                    case "click":
                        await page.ClickAsync(parts[1]);
                        break;
                    case "wait":
                        await page.WaitForTimeoutAsync(int.Parse(parts[1]));
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            passed = false;
            Logger.Log(testName, ex.Message, _config);
        }

        await page.ScreenshotAsync(new()
        {
            Path = Path.Combine(
                _config["AutomationSettings:ResultFolderPath"]!,
                "Screenshots",
                $"{testName}.png")
        });

        HtmlReportGenerator.Generate(
            testName,
            passed,
            Path.Combine(
                _config["AutomationSettings:ResultFolderPath"]!,
                "Reports"));

        await browser.CloseAsync();
    }
}