using System.Collections.Generic;

namespace Automated.OtherTools
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
