using CidadaoAlerta.Data.ADO.Repository;
using CidadaoAlerta.Domain.Interfaces;
using CidadaoAlerta.Infra.DependencyInjection.Interfaces;
using Microsoft.Practices.Unity;
using System;

namespace CidadaoAlerta.Infra.DependencyInjection.Services
{
    public class Container : IDependencyInjection
    {
        private static Container _container;
        private readonly IUnityContainer _unityContainer;

        private Container()
        {
            _unityContainer = new UnityContainer();
            RegisterTypes();
        }

        public static Container GetContainer()
        {
            return _container ?? (_container ?? new Container());
        }

        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public T Resolve<T>(Type type)
        {
            return (T)_unityContainer.Resolve(type);
        }

        private void RegisterTypes()
        {
            _unityContainer
                .RegisterType<IDataContext, DataContext>(new InjectionConstructor())
                .RegisterType<IUsuarioRepository, UsuarioRepository>(new InjectionConstructor())
                .RegisterType<IOcorrenciaRepository, OcorrenciaRepository>(new InjectionConstructor())
                .RegisterType<IInteracaoRepository, InteracaoRepository>(new InjectionConstructor());
        }
    }
}
