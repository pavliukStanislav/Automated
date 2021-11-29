using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Automated.OtherTools.Excel
{
    public class DataCreator
    {
        public static List<ExampleExcelTemplate> GetLanesFileData(int numberOfLanes = default)
        {
            var defaultTemplate = new List<ExampleExcelTemplate>
              {
                ExampleExcelTemplate.Headers()
              };

            if (numberOfLanes == default)
            {
                return defaultTemplate;
            }

            defaultTemplate.AddRange(ExampleExcelTemplate.Data.Generate(numberOfLanes));

            return defaultTemplate;
        }

        /// <summary>
        /// Copy values from one list of models to another
        /// </summary>
        /// <typeparam name="TS"></typeparam>
        /// <typeparam name="TT"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        private static void CopyValues<TS, TT>(TS source, TT target)
        {
            IEnumerable<PropertyInfo> targetProperties = typeof(TT).GetProperties().Where(prop => prop.CanWrite).ToArray();

            IEnumerable<PropertyInfo> sourceProperties = typeof(TS).GetProperties()
                                                                   .Where(prop => prop.CanRead)
                                                                   .Where(sp => targetProperties.Any(tp => tp.Name == sp.Name));

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                object value = sourceProperty.GetValue(source, null);

                PropertyInfo targetProperty = targetProperties.FirstOrDefault(x => x.Name == sourceProperty.Name);

                if (targetProperty != null && value != null)
                {
                    targetProperty.SetValue(target, value, null);
                }
            }
        }
    }
}
