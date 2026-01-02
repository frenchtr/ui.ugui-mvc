using TMPro;
using TravisRFrench.UI.UGUI.MVC.Panels;
using UnityEngine;

namespace TravisRFrench.UI.UGUI.MVC.ScorePanel
{
    public class ScoreIndicatorUIPanel : UIPanel<ScoreIndicatorUIModel>, IScoreIndicatorUIPanel
    {
        [SerializeField]
        private TextMeshProUGUI scoreTextComponent;
        
        public void SetScoreText(string value)
        {
            this.scoreTextComponent.text = value;
        }
    }
}
