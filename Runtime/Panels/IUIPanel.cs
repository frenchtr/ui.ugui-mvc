namespace TravisRFrench.UI.UGUI.MVC.Panels
{
    public interface IUIPanel : IUIView
    {
        PanelState State { get; }
        
        void Open();
        void Close();
    }

    public interface IUIPanel<TModel> : IUIView<TModel>, IUIPanel
        where TModel : class, IUIModel
    {
    }
}
