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
        
        private void OnModelChanged()
        {
            this.UpdateView();
        }

        public void Activate()
        {
            this.OnActivate();
        }

        public void Bind()
        {
            this.Model.Changed += this.OnModelChanged;
            this.OnBind();
        }

        public void Unbind()
        {
            this.Model.Changed -= this.OnModelChanged;
            this.OnUnbind();
        }

        public void Update()
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
    }
}
