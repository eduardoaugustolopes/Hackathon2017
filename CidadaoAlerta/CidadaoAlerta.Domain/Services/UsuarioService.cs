using CidadaoAlerta.Domain.Entities;
using CidadaoAlerta.Domain.Enums;
using CidadaoAlerta.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CidadaoAlerta.Domain.Services
{
    public class UsuarioService
    {
        private readonly IDataContext _dataContext;
        private readonly IUsuarioRepository _usuarioRepository;

        public ResponseService ResponseService;

        private UsuarioService()
        {
            ResponseService = new ResponseService();
        }

        public UsuarioService(IDataContext dataContext,
            IUsuarioRepository usuarioRepository)
        {
            _dataContext = dataContext;
            _usuarioRepository = usuarioRepository;

            ResponseService = new ResponseService();
        }

        public Usuario Get(string login, string senha)
        {
            try
            {
                _dataContext.BeginTransaction();

                var usuarios = _usuarioRepository.Get(login, senha);

                ResponseService = new ResponseService(ResponseTypeEnum.Success, "Usuário recuperado com sucesso.");

                return usuarios;
            }
            catch (Exception ex)
            {
                ResponseService = new ResponseService(ResponseTypeEnum.Error, "Houve uma falha ao recuperar o usuário.");
                return new Usuario();
            }
            finally
            {
                _dataContext.Finally();
            }
        }
    }
}
