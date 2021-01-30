using System.IO;
using System.Reflection;

namespace Automated.Data
{
    public static class FilePath
    {
        private static string AssemblyLocation => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string XlsxFiles = Path.Combine(AssemblyLocation, "Examples", "Files", "Xlsx");
    }
}
