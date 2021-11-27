using System;

namespace Automated.UI.Elements.Interfaces
{
    public interface IBaseElement
    {
        void Click(TimeSpan timeToWait = default);
        string GetAttribute(string attributeName, TimeSpan timeToWait = default);
        bool IsDisplayed(TimeSpan timeToWait = default);
        bool IsNotDisplayed(TimeSpan timeToWait = default);
        void SetElementValue(string value, TimeSpan timeToWait = default);
    }
}