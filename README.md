# autotesting.playwright

Installation
 
Playwright was created specifically to accommodate the needs of end-to-end testing. Playwright supports all modern rendering engines including Chromium, WebKit, and Firefox. Test on Windows, Linux, and macOS, locally or on CI, headless or headed with native mobile emulation.

You can choose to use MSTest, NUnit, or xUnit base classes that Playwright provides to write end-to-end tests. These classes support running tests on multiple browser engines, parallelizing tests, adjusting launch/context options and getting a Page/BrowserContext instance per test out of the box. Alternatively you can use the library to manually write the testing infrastructure.

dotnet new mstest -n autotesting.playwright

cd autotesting.playwright

# Packages

1.dotnet add package Microsoft.Playwright.MSTest
2.pwsh bin/Debug/net8.0/playwright.ps1 install
