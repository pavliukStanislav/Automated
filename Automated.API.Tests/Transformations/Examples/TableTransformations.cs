using Automated.Data.Examples.Contracts;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Automated.API.Tests.Transformations.Examples
{
    [Binding]
    public class TableTransformations
    {
        [StepArgumentTransformation]
        public IEnumerable<ExampleTableItem> TableToExampleTableItem(Table table)
        {
            return table.CreateSet<ExampleTableItem>();
        }
    }
}
