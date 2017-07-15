using CidadaoAlerta.Domain.Entities;
using CidadaoAlerta.Domain.Enums;
using CidadaoAlerta.Domain.Interfaces;
using System;

namespace CidadaoAlerta.Domain.Services
{
    public class InteracaoService
    {
        private readonly IDataContext _dataContext;
        private readonly IInteracaoRepository _interacaoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ResponseService ResponseService;

        private InteracaoService()
        {
            ResponseService = new ResponseService();
        }

        public InteracaoService(IDataContext dataContext,
            IInteracaoRepository interacaoRepository,
            IUsuarioRepository usuarioRepository)
        {
            _dataContext = dataContext;
            _interacaoRepository = interacaoRepository;
            _usuarioRepository = usuarioRepository;

            ResponseService = new ResponseService();
        }

        public void Add(Interacao interacao)
        {
            using (var dataContext = _dataContext)
            {
                try
                {
                    dataContext.BeginTransaction();
                    if (ValidaInteracao(interacao))
                    {
                        interacao.Data = DateTime.Now;
                        _interacaoRepository.Add(interacao);

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

        private bool ValidaInteracao(Interacao interacao)
        {
            ResponseService = new ResponseService();

            if (string.IsNullOrEmpty(interacao.Descricao))
            {
                ResponseService.FieldsInvalids.Add("Descricao");
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
