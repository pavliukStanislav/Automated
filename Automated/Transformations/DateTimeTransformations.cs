﻿using System;
using TechTalk.SpecFlow;

namespace Automated.Transformations
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
