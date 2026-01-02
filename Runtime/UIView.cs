using TravisRFrench.Dependencies.Injection;
using TravisRFrench.Lifecycles.Runtime;
using UnityEngine;

namespace TravisRFrench.UI.UGUI.MVC
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class UIView<TModel> : ManagedMonoBehaviour, IUIView<TModel>
        where TModel : class, IUIModel
    {
        [SerializeField]
        private TModel model;
        [Inject]
        private IUIController controller;
        private float previousAlpha;

        TModel IUIView<TModel>.Model => this.model;
        [Inject]
        protected Canvas Canvas { get; private set; }
        [Inject]
        protected CanvasGroup CanvasGroup { get; private set; }

        public bool IsActive => this.gameObject.activeSelf;
        public bool IsVisible => this.CanvasGroup.alpha > 0;
        public bool IsInteractable => this.CanvasGroup.interactable;
        
        public void SetActive(bool isActive)
        {
            this.gameObject.SetActive(isActive);
        }
        
        public void SetVisible(bool isVisible)
        {
            this.previousAlpha = this.CanvasGroup.alpha;
            this.CanvasGroup.alpha = isVisible ? this.previousAlpha : 0;
        }
        
        public void SetInteractable(bool isInteractable)
        {
            this.CanvasGroup.interactable = isInteractable;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.controller.Activate();
            this.controller.UpdateView();
        }

        protected override void OnBind()
        {
            base.OnBind();
            this.controller.Bind();
        }

        protected override void OnUnbind()
        {
            base.OnUnbind();
            this.controller.Unbind();
        }
        
        protected virtual void OnValidate()
        {
            this.controller?.UpdateView();
        }

        private void Update()
        {
            this.controller?.Update();
        }
    }
}
