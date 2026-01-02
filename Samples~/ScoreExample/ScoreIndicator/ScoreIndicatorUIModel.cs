using System;
using UnityEngine;

namespace TravisRFrench.UI.UGUI.MVC.ScorePanel
{
    [Serializable]
    public class ScoreIndicatorUIModel : UIModel
    {
        [SerializeField]
        private string scoreText;

        public string ScoreText
        {
            get => this.scoreText;
            set
            {
                this.scoreText = value;
                this.NotifyChanged();
            }
        }
    }
}
