using System;

namespace Automated.UI.Elements.Interfaces
{
    public interface ITextBox: IBaseElement
    {
        string Text { get; set; }
        string Value { get; set; }

        bool IsTextEqualTo(string text, TimeSpan timeToWait);
    }
}