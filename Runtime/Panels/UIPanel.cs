namespace TravisRFrench.UI.UGUI.MVC.Panels
{
    public class UIPanel<TModel> : UIView<TModel>, IUIPanel<TModel>
        where TModel : class, IUIModel
    {
        public PanelState State { get; private set; }

        protected override void OnCompose()
        {
            base.OnCompose();

            this.State = PanelState.Open;
        }

        public void Open()
        {
            if (this.State != PanelState.Closed)
            {
                return;
            }
            
            this.State = PanelState.Opening;
        }
        
        public void Close()
        {
            if (this.State != PanelState.Open)
            {
                return;
            }
            
            this.SetInteractable(false);
            this.State = PanelState.Closing;
        }

        protected virtual void OnOpened()
        {
        }

        protected virtual void OnClosed()
        {
        }
    }
}
