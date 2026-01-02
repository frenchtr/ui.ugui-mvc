using System;
using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Dependencies.Containers;
using TravisRFrench.Dependencies.Installers;
using UnityEngine;

namespace TravisRFrench.UI.UGUI.MVC
{
    public abstract class UIViewInstaller<TModel, TView, TController> : MonoInstaller
        where TModel : class, IUIModel
        where TView : IUIView<TModel>
        where TController : IUIController
    {
        public override void InstallBindings(IContainer container)
        {
            var view = this.GetComponent<TView>();
            var model = view.Model;
            
            container.Bind<TModel>()
                .ToSelf()
                .FromInstance(model)
                .AsSingleton();

            var interfaceTypes = GetUIViewInterfaces(typeof(TView));
            foreach (var interfaceType in interfaceTypes)
            {
                container.Bind(interfaceType)
                    .To<TView>()
                    .FromInstance(view)
                    .AsSingleton();
            }
            
            container.Bind<IUIController>()
                .To<TController>()
                .FromNew()
                .AsSingleton();
            
            var canvas = this.GetComponent<Canvas>();
            var canvasGroup = this.GetComponent<CanvasGroup>();
            
            container.Bind<Canvas>()
                .ToSelf()
                .FromInstance(canvas)
                .AsSingleton();

            container.Bind<CanvasGroup>()
                .ToSelf()
                .FromInstance(canvasGroup)
                .AsSingleton();
        }
        
        private static IReadOnlyList<Type> GetUIViewInterfaces(Type viewType)
        {
            if (viewType == null)
            {
                throw new ArgumentNullException(nameof(viewType));
            }

            // If TView is itself an interface, include it as well as its inherited interfaces.
            // If it's a class, GetInterfaces() already includes all inherited interfaces.
            var interfaces =
                viewType.IsInterface
                    ? new[] { viewType }
                        .Concat(viewType.GetInterfaces())
                    : viewType.GetInterfaces();

            return interfaces
                .Where(i => i != typeof(IUIView) && typeof(IUIView).IsAssignableFrom(i))
                .Distinct()
                .ToArray();
        }
    }
}
