using CidadaoAlerta.Domain.Entities;
using CidadaoAlerta.Domain.Interfaces;
using CidadaoAlerta.Domain.Services;
using CidadaoAlerta.Infra.DependencyInjection.Services;
using System.Collections.Generic;

namespace CidadaoAlerta.Application.Application
{
    public class OcorrenciaApplication
    {
        private static readonly OcorrenciaService _ocorrenciaService = new OcorrenciaService(
            DependencyInjectionService.Resolve<IDataContext>(),
            DependencyInjectionService.Resolve<IOcorrenciaRepository>(),
            DependencyInjectionService.Resolve<IUsuarioRepository>());

        public static string ResponseMessage
        {
            get
            {
                return _ocorrenciaService.ResponseService.Message;
            }
        }

        public static string ResponseType
        {
            get
            {
                return _ocorrenciaService.ResponseService.Type.ToString();
            }
        }

        public static List<string> FieldsInvalids
        {
            get
            {
                return _ocorrenciaService.ResponseService.FieldsInvalids;
            }
        }

        public static void Add(Ocorrencia ocorrencia)
        {
            _ocorrenciaService.Add(ocorrencia);
        }
    }
}
