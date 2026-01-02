using UnityEngine;

namespace TravisRFrench.UI.UGUI.MVC.Layers
{
    public interface IUILayer
    {
        void Insert(int index, RectTransform rectTransform);
        void Add(RectTransform rectTransform);
    }
}
