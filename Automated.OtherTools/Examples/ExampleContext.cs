using System.Collections.Generic;

namespace Automated.OtherTools.Examples
{
    public class ExampleContext
    {
        public List<string> SomeList { get; set; }
        public ExampleContext()
        {
            SomeList = new List<string>();
        }
    }
}
