namespace TravisRFrench.UI.UGUI.MVC
{
    public interface IUIView
    {
        bool IsActive { get; }
        bool IsVisible { get; }
        bool IsInteractable { get; }
        
        void SetActive(bool isActive);
        void SetVisible(bool isVisible);
        void SetInteractable(bool isInteractable);
    }

    public interface IUIView<out TModel> : IUIView
        where TModel : class, IUIModel
    {
        TModel Model { get; }
    }
}
