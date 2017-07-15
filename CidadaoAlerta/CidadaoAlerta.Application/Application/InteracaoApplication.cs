using CidadaoAlerta.Domain.Entities;
using CidadaoAlerta.Domain.Interfaces;
using CidadaoAlerta.Domain.Services;
using CidadaoAlerta.Infra.DependencyInjection.Services;
using System.Collections.Generic;

namespace CidadaoAlerta.Application.Application
{
    public class InteracaoApplication
    {
        private static readonly InteracaoService _interacaoService = new InteracaoService(
            DependencyInjectionService.Resolve<IDataContext>(),
            DependencyInjectionService.Resolve<IInteracaoRepository>(),
            DependencyInjectionService.Resolve<IUsuarioRepository>());

        public static string ResponseMessage
        {
            get
            {
                return _interacaoService.ResponseService.Message;
            }
        }

        public static string ResponseType
        {
            get
            {
                return _interacaoService.ResponseService.Type.ToString();
            }
        }

        public static List<string> FieldsInvalids
        {
            get
            {
                return _interacaoService.ResponseService.FieldsInvalids;
            }
        }

        public static void Add(Interacao interacao)
        {
            _interacaoService.Add(interacao);
        }
    }
}
