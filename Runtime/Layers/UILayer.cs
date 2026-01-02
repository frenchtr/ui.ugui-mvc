using TravisRFrench.Lifecycles.Runtime;
using UnityEngine;

namespace TravisRFrench.UI.UGUI.MVC.Layers
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasGroup))]
    public class UILayer : ManagedMonoBehaviour, IUILayer
    {
        public void Insert(int index, RectTransform rectTransform)
        {
            rectTransform.SetParent(this.transform);
            rectTransform.SetSiblingIndex(index);
        }
        
        public void Add(RectTransform rectTransform)
        {
            rectTransform.SetParent(this.transform);
            rectTransform.SetAsLastSibling();
        }
    }
}
