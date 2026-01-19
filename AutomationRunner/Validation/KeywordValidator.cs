using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationRunner.Validation;

public static class KeywordValidator
{
    private static readonly HashSet<string> Allowed = new()
    {
        "goto", "fill", "click", "wait"
    };

    public static void Validate(string step)
    {
        var keyword = step.Split(' ')[0].ToLower();
        if (!Allowed.Contains(keyword))
            throw new Exception($"Invalid keyword: {keyword}");
    }
}