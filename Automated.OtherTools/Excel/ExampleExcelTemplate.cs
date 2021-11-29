using Bogus;

namespace Automated.OtherTools.Excel
{
    public class ExampleExcelTemplate
    {
        public object CellOne { get; set; }

        public object CellTwo { get; set; }

        public object CellThree { get; set; }

        public static Faker<ExampleExcelTemplate> Data =>
            new Faker<ExampleExcelTemplate>("en_US")
            .RuleFor(x => x.CellOne, y => $"{y.IndexFaker + 1}")
            .RuleFor(x => x.CellTwo, y => y.Address.City())
            .RuleFor(x => x.CellThree, y => y.Random.Bool().ToString());

        public static ExampleExcelTemplate Headers() =>
            new ExampleExcelTemplate
            {
                CellOne = "Cell one",
                CellTwo = "Cell two",
                CellThree = "Cell three"
            };
    }
}
