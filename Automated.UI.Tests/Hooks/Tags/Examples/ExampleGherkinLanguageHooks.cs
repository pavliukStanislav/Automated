﻿using System;
using TechTalk.SpecFlow;

namespace Automated.UI.Tests.Hooks.Tags.Examples
{
    [Binding]
    public class ExampleGherkinLanguageHooks
    {
        [BeforeScenario("someTag")]
        public void SomeTag()
        {
            Console.WriteLine("someTag action");
        }
    }
}
