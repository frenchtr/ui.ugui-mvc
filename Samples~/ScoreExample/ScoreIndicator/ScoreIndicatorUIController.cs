namespace TravisRFrench.UI.UGUI.MVC.ScorePanel
{
    public class ScoreIndicatorUIController : UIController<ScoreIndicatorUIModel, IScoreIndicatorUIPanel>
    {
        private readonly IScoreService scoreService;
        
        public ScoreIndicatorUIController(ScoreIndicatorUIModel model, IScoreIndicatorUIPanel view, IScoreService scoreService)
            : base(model, view)
        {
            this.scoreService = scoreService;
        }

        protected override void OnBind()
        {
            this.scoreService.ScoreChanged += this.OnScoreChanged;
        }

        protected override void OnUnbind()
        {
            this.scoreService.ScoreChanged -= this.OnScoreChanged;
        }

        public override void UpdateView()
        {
            this.View.SetScoreText(this.Model.ScoreText);
        }

        private void OnScoreChanged()
        {
            var score = this.scoreService.Score;
            this.Model.ScoreText = $"Score: {score}";
        }
    }
}
