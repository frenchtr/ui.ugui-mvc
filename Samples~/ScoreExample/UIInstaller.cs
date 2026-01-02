using TravisRFrench.Dependencies.Containers;
using TravisRFrench.Dependencies.Installers;
using UnityEngine;

namespace TravisRFrench.UI.UGUI.MVC
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasGroup))]
    public class UIInstaller : MonoInstaller
    {
        private const string UIRootInjectedName = "uiRoot";
        private const string RootCanvasInjectedName = "rootCanvas";
        private const string RootCanvasGroupInjectedName = "rootCanvasGroup";
        private const string UICameraInjectedName = "uiCamera";

        [SerializeField]
        private Camera uiCamera;
        
        public override void InstallBindings(IContainer container)
        {
            var uiRoot = this.GetComponent<IUIRoot>();
            var canvas = this.GetComponent<Canvas>();
            var canvasGroup = this.GetComponent<CanvasGroup>();
            
            container.Bind<IUIRoot>()
                .To<UIRoot>()
                .FromInstance(uiRoot)
                .AsSingleton()
                .WhenNamed(UIRootInjectedName);

            container.Bind<Canvas>()
                .ToSelf()
                .FromInstance(canvas)
                .AsSingleton()
                .WhenNamed(RootCanvasInjectedName);
            
            container.Bind<CanvasGroup>()
                .ToSelf()
                .FromInstance(canvasGroup)
                .AsSingleton()
                .WhenNamed(RootCanvasGroupInjectedName);
            
            container.Bind<Camera>()
                .ToSelf()
                .FromInstance(this.uiCamera)
                .AsSingleton()
                .WhenNamed(UICameraInjectedName);
        }
    }
}
