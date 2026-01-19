using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationRunner.Utils;
public static class ConfigHelper
{
    public static IConfiguration Load()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory) // 🔥 IMPORTANT
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }
     
}