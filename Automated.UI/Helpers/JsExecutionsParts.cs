namespace Automated.UI.Helpers
{
    internal static class JsExecutionsParts
    {
        internal const string SetAttribute = "arguments[0].setAttribute(arguments[1], arguments[2])";

        internal const string ReadyState = "return document.readyState == 'complete'";

        internal const string ScrollToElement = "arguments[0].scrollIntoView(true);";

        internal const string OpenNewWindow = "window.open();";

        internal const string SetZoom = "document.body.style.zoom= (arguments[0] + '%')";

        internal const string SetWindowTitle = "document.title = arguments[0]";

        internal const string CleanValue = "arguments[0].value = '';";
    }
}
