using System;
using TechTalk.SpecFlow;

namespace Automated.Tests.Transformations.Examples
{
    [Binding]
    public class DateTimeTransformations
    {
        [StepArgumentTransformation(@"in (\d+) days")]
        public DateTime InXDaysTransform(int days)
        {
            return DateTime.Now.AddDays(days);
        }
    }
}
