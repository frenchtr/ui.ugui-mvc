namespace TravisRFrench.UI.UGUI.MVC
{
    public abstract class UIController<TModel, TView> : IUIController<TModel, TView>
        where TModel : class, IUIModel
        where TView : IUIView
    {
        public TModel Model { get; }
        public TView View { get; }

        protected UIController(TModel model, TView view)
        {
            this.Model = model;
            this.View = view;
        }

        public virtual void UpdateView()
        {
        }

        void IUIController.Activate()
        {
            this.OnActivate();
        }

        void IUIController.Bind()
        {
            this.Model.Changed += this.OnModelChanged;
            this.OnBind();
        }

        void IUIController.Unbind()
        {
            this.Model.Changed -= this.OnModelChanged;
            this.OnUnbind();
        }

        void IUIController.Update()
        {
            this.OnUpdate();
        }

        protected virtual void OnActivate()
        {
        }

        protected virtual void OnBind()
        {
        }

        protected virtual void OnUnbind()
        {
        }

        protected virtual void OnUpdate()
        {
        }
        
        private void OnModelChanged()
        {
            this.UpdateView();
        }
    }
}
