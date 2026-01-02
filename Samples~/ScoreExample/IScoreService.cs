using System;

namespace TravisRFrench.UI.UGUI.MVC
{
    public interface IScoreService
    {
        int Score { get; }
        
        event Action ScoreChanged;
        
        void IncrementScore();
    }
}
