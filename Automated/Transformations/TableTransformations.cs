using Automated.Data.Contracts;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Automated.Transformations
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
