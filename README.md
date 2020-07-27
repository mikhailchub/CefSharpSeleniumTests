# CefSharp Selenium Tests
Example of Selenium tests for CefSharp application 
(for the CefSharp demo app see another rep: https://github.com/mikhailchub/CefSharpExample)

Key things to make it work:
1. CefSharp app is to be built with the debugging port enabled
```c#
    var settings = new CefSettings();
    settings.RemoteDebuggingPort = 8081;
    Cef.Initialize(settings);
```
2. Version of Selenium.WebDriver.ChromeDriver in the test project is to be aligned with the version of cef.redist libraries in the CefSharp app. (e.g. this example is based on ChromeDriver v81. as well as the demo app is built on Chromium v81)
3. Tests initialization part should include setting of the ChromeOptions object property "DebuggerAddress"
```c#
    ChromeOptions options = new ChromeOptions();
    options.DebuggerAddress = "localhost:8081";
    driver = new ChromeDriver(options);
```
