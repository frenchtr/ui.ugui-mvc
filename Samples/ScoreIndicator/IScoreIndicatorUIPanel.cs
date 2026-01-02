using TravisRFrench.UI.UGUI.MVC.Panels;

namespace TravisRFrench.UI.UGUI.MVC.ScorePanel
{
    public interface IScoreIndicatorUIPanel : IUIPanel<ScoreIndicatorUIModel>
    {
        void SetScoreText(string value);
    }
}
