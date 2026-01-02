using TravisRFrench.Lifecycles.Runtime;
using UnityEngine;

namespace TravisRFrench.UI.UGUI.MVC.Layers
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasGroup))]
    public class UILayer : ManagedMonoBehaviour, IUILayer
    {
        public RectTransform RectTransform => this.transform as RectTransform;
        
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
