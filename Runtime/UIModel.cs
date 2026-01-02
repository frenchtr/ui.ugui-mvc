using System;

namespace TravisRFrench.UI.UGUI.MVC
{
    [Serializable]
    public abstract class UIModel : IUIModel
    {
        public event Action Changed;
        
        public void NotifyChanged()
        {
            this.Changed?.Invoke();
        }
    }
}
