using System;

namespace TravisRFrench.UI.UGUI.MVC
{
    public class ScoreService : IScoreService
    {
        public int Score { get; private set; }
        
        public event Action ScoreChanged;
        
        public void IncrementScore()
        {
            this.Score++;
            this.ScoreChanged?.Invoke();
        }
    }
}
