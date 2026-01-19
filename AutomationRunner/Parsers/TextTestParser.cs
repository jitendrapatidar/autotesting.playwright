using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationRunner.Parsers;

public static class TextTestParser
{
    public static string[] Parse(string filePath)
    {
        return File.ReadAllLines(filePath)
                   .Where(l => !string.IsNullOrWhiteSpace(l))
                   .ToArray();
    }
}