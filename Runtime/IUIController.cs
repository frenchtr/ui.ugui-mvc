namespace TravisRFrench.UI.UGUI.MVC
{
    public interface IUIController
    {
        void Activate();
        void Bind();
        void Unbind();
        void Update();
        void UpdateView();
    }

    public interface IUIController<TModel, TView> : IUIController
        where TModel : class, IUIModel
        where TView : IUIView
    {
        TModel Model { get; }
        TView View { get; }
    }
}
