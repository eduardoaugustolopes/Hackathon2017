using CidadaoAlerta.Domain.Entities;
using CidadaoAlerta.Domain.Enums;
using CidadaoAlerta.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace CidadaoAlerta.Domain.Services
{
    public class OcorrenciaService
    {
        private readonly IDataContext _dataContext;
        private readonly IOcorrenciaRepository _ocorrenciaRepository;
        private readonly IInteracaoRepository _interacaoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ResponseService ResponseService;

        private OcorrenciaService()
        {
            ResponseService = new ResponseService();
        }

        public OcorrenciaService(IDataContext dataContext,
            IOcorrenciaRepository ocorrenciaRepository,
            IInteracaoRepository interacaoRepository,
            IUsuarioRepository usuarioRepository)
        {
            _dataContext = dataContext;
            _ocorrenciaRepository = ocorrenciaRepository;
            _interacaoRepository = interacaoRepository;
            _usuarioRepository = usuarioRepository;

            ResponseService = new ResponseService();
        }

        public void Add(Ocorrencia ocorrencia)
        {
            using (var dataContext = _dataContext)
            {
                try
                {
                    dataContext.BeginTransaction();
                    if (ValidaOcorrencia(ocorrencia))
                    {
                        ocorrencia.Data = DateTime.Now;
                        _ocorrenciaRepository.Add(ocorrencia);

                        dataContext.Commit();
                    }
                }
                catch (Exception ex)
                {
                    dataContext.Rollback();
                    ResponseService = new ResponseService(ResponseTypeEnum.Error, "Erro ao cadastrar a operação.");
                }
                finally
                {
                    dataContext.Finally();
                }
            }
        }

        public List<Ocorrencia> Get()
        {
            using (var dataContext = _dataContext)
            {
                try
                {
                    dataContext.BeginTransaction();

                    var ocorrencias = _ocorrenciaRepository.Get();

                    ResponseService = new ResponseService(ResponseTypeEnum.Success, "Ocorrências consultadas com sucesso!");
                    return ocorrencias;
                }
                catch (Exception ex)
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Error, "Erro ao recuperar as ocorrências.");
                    return null;
                }
                finally
                {
                    dataContext.Finally();
                }
            }
        }

        public Ocorrencia Get(int id)
        {
            using (var dataContext = _dataContext)
            {
                try
                {
                    dataContext.BeginTransaction();

                    var ocorrencia = _ocorrenciaRepository.Get(id);
                    ocorrencia.Interacoes = _interacaoRepository.GetPorOcorrencia(id);

                    ResponseService = new ResponseService(ResponseTypeEnum.Success, "Ocorrência consultadas com sucesso!");
                    return ocorrencia;
                }
                catch (Exception ex)
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Error, "Erro ao recuperar a ocorrência.");
                    return null;
                }
                finally
                {
                    dataContext.Finally();
                }
            }
        }

        private bool ValidaOcorrencia(Ocorrencia ocorrencia)
        {
            ResponseService = new ResponseService();

            if (string.IsNullOrEmpty(ocorrencia.Descricao))
            {
                ResponseService.FieldsInvalids.Add("Descricao");
            }
            if (ocorrencia.TipoOcorrencia == TipoOcorrenciaEnum.None)
            {
                ResponseService.FieldsInvalids.Add("TipoOcorrencia");
            }
            if (ocorrencia.TipoOcorrencia == TipoOcorrenciaEnum.Assalto && ocorrencia.TipoItem == TipoItemEnum.None)
            {
                ResponseService.FieldsInvalids.Add("TipoItem");
            }

            if (ResponseService.FieldsInvalids.Count > 0)
            {
                ResponseService.Message += "Informe os dados corretamente.";
            }
            ResponseService.Type =
                string.IsNullOrEmpty(ResponseService.Message) ?
                    ResponseTypeEnum.Success :
                    ResponseTypeEnum.Warning;
            return ResponseService.Type == ResponseTypeEnum.Success;
        }
    }
}
