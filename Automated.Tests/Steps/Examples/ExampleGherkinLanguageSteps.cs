using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Automated.Tests.Steps
{
    [Binding]
    public class ExampleGherkinLanguageSteps
    {
        [Given(@"this is given for all scenarious in feature")]
        public void GivenThisIsGivenForAllScenariousInFeature()
        {
            Console.WriteLine("this is given for all scenarious in feature");
        }

        [Given(@"this is given")]
        public void GivenThisIsGiven()
        {
            Console.WriteLine("this is given");
        }

        [Given(@"this is and")]
        public void GivenThisIsAnd()
        {
            Console.WriteLine("this is and");
        }

        [Given(@"this is asterisk")]
        public void GivenThisIsAsterisk()
        {
            Console.WriteLine("this is asterisk");
        }

        [When(@"this is when with '(.*)' parameter")]
        public void WhenThisIsWhenWithParameter(string p0)
        {
            Console.WriteLine($"this is when with '{p0}' parameter");
        }

        [Then(@"this is then with int '(.*)' parameter")]
        public void ThenThisIsThenWithIntParameter(int p0)
        {
            Console.WriteLine($"this is then with int '{p0}' parameter");
        }

        [Then(@"this is failed but")]
        public void ThenThisIsBut()
        {
            Console.WriteLine("this is failed but");
            (true).Should().BeFalse();
        }

        [Given(@"step with (.*) parameter")]
        [When(@"step with (.*) parameter")]
        public void GivenStepWithParameter(int p0)
        {
            Console.WriteLine($"step with {p0} parameter");
        }

        [Given(@"this is given with large string")]
        public void GivenThisIsGivenWithLargeString(string multilineText)
        {
            Console.WriteLine("this is given with large string");
            Console.WriteLine("string: ");
            Console.WriteLine(multilineText);
        }

        [Given(@"this is given with table")]
        public void GivenThisIsGivenWithTable(Table table)
        {
            Console.WriteLine("this is given with table");

            Console.WriteLine("table: ");
            WriteTableRow(table.Header);
            foreach (var row in table.Rows)
            {
                WriteTableRow(row.Values);
            }
        }

        private void WriteTableRow<T>(ICollection<T> collection)
        {
            collection.ToList().ForEach(x => Console.Write($"| {x} |"));
            Console.WriteLine();
        }
    }
}
