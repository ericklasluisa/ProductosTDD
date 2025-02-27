﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollTestProject1.Utilities
{
    public static class WebDriverManager
    {
        public static IWebDriver GetDriver(string browser)
        {
            return browser.ToLower() switch
            {
                "chrome" => new OpenQA.Selenium.Chrome.ChromeDriver(),
                "firefox" => new OpenQA.Selenium.Firefox.FirefoxDriver(),
                "edge" => new OpenQA.Selenium.Edge.EdgeDriver(),
                _ => throw new NotSupportedException($"Navegador {browser} no soportado."),
            };
        }
    }
}
