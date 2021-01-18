using Automated.Data.Contracts;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Automated.Steps
{
    [Binding]
    public sealed class AssistHelpersSteps
    {
        [Given(@"Create instance from table")]
        public void GivenCreateInstanceFromTable(Table table)
        {
            var instance = table.CreateInstance<ExampleTableItem>();
            Console.WriteLine("This is output");
            Console.WriteLine(instance.First);
        }

        [When(@"Create another instanse from tabe")]
        public void WhenCreateAnotherInstanseFromTabe(Table table)
        {
            var inst = table.CreateInstance<ExampleTableItem>();

            Console.WriteLine("This is out:");
            Console.WriteLine(inst.First);
        }

        [When(@"Compare instance")]
        public void WhenCompareInstance(Table table)
        {
            var perfect = new ExampleTableItem()
            {
                First = "First perfect",
                Second = "Second perfect"
            };

            table.CompareToInstance<ExampleTableItem>(perfect);
        }
    }
}
