using System;

namespace TravisRFrench.UI.UGUI.MVC
{
    public interface IUIModel
    {
        event Action Changed;

        void NotifyChanged();
    }
}
