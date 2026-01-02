using TravisRFrench.Dependencies.Containers;
using TravisRFrench.Dependencies.Installers;

namespace TravisRFrench.UI.UGUI.MVC
{
    public class SampleInstaller : MonoInstaller
    {
        public override void InstallBindings(IContainer container)
        {
            container.Bind<IScoreService>()
                .To<ScoreService>()
                .FromNew()
                .AsSingleton();
        }
    }
}
