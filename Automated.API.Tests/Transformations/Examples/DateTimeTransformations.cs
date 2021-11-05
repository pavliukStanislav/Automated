using System;
using TechTalk.SpecFlow;

namespace Automated.API.Tests.Transformations.Examples
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
